using EShopAPI.Common.Enums;
using EShopAPI.Common;
using EShopAPI.Cores.Auth.JWTs;
using EShopAPI.Cores.MapRolePermissions;
using EShopAPI.Cores.MapUserRoles.Services;
using EShopAPI.Cores.MapUserRoles;
using EShopAPI.Cores.ShopPermissions;
using EShopCores.Responses;
using Jose;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace EShopAPI.Filters.RequiredPermissionFilters
{
    /// <summary>
    /// RequiredPermission Base Filter
    /// </summary>
    public class RequiredPermissionBaseAttribute : IAuthorizationFilter
    {
        private readonly IJwtService _jwtService;
        private readonly IMapUserRoleService _mapUserRoleService;
        private readonly LoginUserData _loginUserData;
        private readonly ShopPermissionType _type;
        private readonly List<HttpMethodType> _cruds = new List<HttpMethodType>();

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="jwtService"></param>
        /// <param name="mapUserRoleService"></param>
        /// <param name="loginUserData"></param>
        /// <param name="type"></param>
        /// <param name="cruds"></param>
        public RequiredPermissionBaseAttribute(IJwtService jwtService,
            IMapUserRoleService mapUserRoleService,
            LoginUserData loginUserData,
            ShopPermissionType type,
            params HttpMethodType[] cruds
            )
        {
            _jwtService = jwtService;
            _mapUserRoleService = mapUserRoleService;
            _loginUserData = loginUserData;
            _type = type;
            _cruds.AddRange(cruds);
        }

        /// <inheritdoc/>
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            string? token = context.HttpContext.Request.Headers["Authorization"].FirstOrDefault();
            if (string.IsNullOrWhiteSpace(token))
            {
                context.Result = new ObjectResult(
                    GenericResponse<string>.GetResult(ResponseCodeType.TokenIsNullOrEmpty, "Token不可為null或空白"))
                {
                    StatusCode = StatusCodes.Status401Unauthorized
                };

                return;
            }

            JwtPayload jwtPayload;

            try
            {
                jwtPayload = _jwtService.DecryptToken(token!);
            }
            catch (IntegrityException integrityException)
            {
                context.Result = new ObjectResult(
                    GenericResponse<string>.GetResult(ResponseCodeType.InvalidToken,
                    $"Token decode Error. exception:{integrityException}"))
                {
                    StatusCode = StatusCodes.Status401Unauthorized
                };

                return;
            }

            _loginUserData.SetLoginUserData(jwtPayload);

            //如果是管理者就不檢查權限
            if (_loginUserData.IsAdmin)
            {
                return;
            }

            //取得該user的所有角色清單
            IList<MapUserRole> mapUserRoles = _mapUserRoleService
                .GetByUserId(jwtPayload.UserId)
                .Include(mur => mur.ShopRole)
                    .ThenInclude(role => role!.MapRolePermissions!)
                    .ThenInclude(mrp => mrp!.ShopPermission)
                .ToList();

            string permissionNumber = Enum.GetName(typeof(ShopPermissionType), _type)!;

            if (!CheckPermission(mapUserRoles, permissionNumber) ||
                !CheckCrud(mapUserRoles, permissionNumber))
            {
                AccessDenied(context);
                return;
            }
        }

        /// <summary>
        /// 檢查是否有該method的權限
        /// </summary>
        /// <param name="mapUserRoles">該user的所有角色清單</param>
        /// <param name="permissionNumber">權限代碼</param>
        /// <returns> 
        /// true = 檢查通過
        /// false = 檢查失敗
        /// </returns>
        private static bool CheckPermission(IList<MapUserRole> mapUserRoles, string permissionNumber)
        {
            //取得所有角色有關該次Request的權限清單
            IList<ShopPermission> permissions = mapUserRoles
                .SelectMany(mur => mur.ShopRole!.MapRolePermissions!)
                .Select(mrp => mrp.ShopPermission!)
                .Where(permission => permission!.Number == permissionNumber)
                .ToList();

            //如果沒有該權限 就return 403
            if (permissions.Count <= 0)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// 檢查該user對method crud 的權限
        /// </summary>
        /// <param name="mapUserRoles">該user的所有角色清單</param>
        /// <param name="permissionNumber">權限代碼</param>
        /// <returns> 
        /// true = 檢查通過
        /// false = 檢查失敗
        /// </returns>
        private bool CheckCrud(IList<MapUserRole> mapUserRoles, string permissionNumber)
        {
            //取得該功能的CRUD權限
            IList<MapRolePermission> mapRolePermissions = mapUserRoles
                .SelectMany(mur => mur.ShopRole!.MapRolePermissions!)
                .Where(mrp => mrp.ShopPermission!.Number == permissionNumber)
                .ToList();

            bool result = _cruds.Select(httpMethodType =>
            {
                Dictionary<HttpMethodType, bool> permissions = new()
                {
                    { HttpMethodType.GET,  mapRolePermissions.Any(mrp => mrp.IsReadPermission)},
                    { HttpMethodType.POST,  mapRolePermissions.Any(mrp => mrp.IsCreatePermission)},
                    { HttpMethodType.PATCH,  mapRolePermissions.Any(mrp => mrp.IsUpdatePermission)},
                    { HttpMethodType.PUT,  mapRolePermissions.Any(mrp => mrp.IsUpdatePermission)},
                    { HttpMethodType.DELETE,  mapRolePermissions.Any(mrp => mrp.IsDeletePermission)},
                };

                return permissions[httpMethodType];
            })
            .All(crud => crud == true);

            return result;
        }

        /// <summary>
        /// 拒絕訪問 (403)
        /// </summary>
        /// <param name="context"></param>
        private static void AccessDenied(AuthorizationFilterContext context)
        {
            context.Result = new ObjectResult(
            GenericResponse<string>
                    .GetResult(ResponseCodeType.InvalidToken, $"Token permission Error."))
            {
                StatusCode = StatusCodes.Status403Forbidden
            };
        }
    }
}
