﻿using EShopAPI.Cores.MapUserRoles;
using EShopAPI.Cores.MapUserRoles.Services;
using EShopAPI.Cores.ShopActions;
using EShopAPI.Cores.ShopUsers;
using EShopAPI.Settings;
using EShopCores.Extensions;
using Jose;
using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Text.Json;

namespace EShopAPI.Cores.Auth.JWTs
{
    /// <summary>
    /// JWT Service
    /// </summary>
    public class JWTService : IJWTService
    {
        //一小時
        private const int AccessTokenExpireTime = 1800;

        //一天
        private const int RefreshTokenExpireTime = 86400; 

        private readonly JwtTokenSettings _jwtTokenSettings;
        private readonly IMapUserRoleService _mapUserRoleService;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="jwtTokenSettings"></param>
        /// <param name="mapUserRoleService"></param>
        public JWTService(JwtTokenSettings jwtTokenSettings, IMapUserRoleService mapUserRoleService)
        {
            _jwtTokenSettings = jwtTokenSettings;
            _mapUserRoleService = mapUserRoleService;
        }

        ///<inheritdoc/>
        public async Task<string> GenerateAccessTokenAsync(ShopUser shopUser)
        {
            //查詢該user的角色>權限>功能
            IList<MapUserRole> mapUserRoles = await _mapUserRoleService.GetByUserId(shopUser.Id)
                .Include(user => user.ShopRole!)
                    .ThenInclude(role => role.MapRolePermissions!)
                    .ThenInclude(map => map.ShopPermission!)
                    .ThenInclude(per => per.MapPermissionActions!)
                    .ThenInclude(action => action.ShopAction)
                .ToListAsync();

            //組功能清單
            IList<ShopAction> shopActions = mapUserRoles.SelectMany(m => m.ShopRole!.MapRolePermissions!)
                    .Select(map => map.ShopPermission!)
                    .SelectMany(m => m.MapPermissionActions!)
                    .Select(s => s.ShopAction!)
                    .ToList();

            return GetToken(shopUser, AccessTokenExpireTime);
        }

        ///<inheritdoc/>
        public string GenerateRefreshToken(ShopUser shopUser)
        {
            return GetToken(shopUser, RefreshTokenExpireTime);
        }

        /// <summary>
        /// 取得Token
        /// </summary>
        /// <param name="shopUser">使用者資訊</param>
        /// <param name="expireTime">到期時間</param>
        /// <param name="shopActions">功能列表</param>
        /// <returns></returns>
        private string GetToken(ShopUser shopUser, int expireTime, IList<ShopAction>? shopActions = null ) 
        {
            DateTime iat = DateTime.Now;
            DateTime exp = iat.AddSeconds(expireTime);

            var payload = new JWTPayload
            {
                Subject = shopUser.Number,
                Issuer = _jwtTokenSettings.Issuer,
                IssuedAt = iat.GetUnixTimestampSecond(),
                Expiration = exp.GetUnixTimestampSecond(),
                ShopActions = shopActions,
            };

            string json = JsonSerializer.Serialize(payload);
            string token = JWT.Encode(json, Encoding.UTF8.GetBytes(_jwtTokenSettings.SignKey), JwsAlgorithm.HS256);
            return token;
        }
    }
}
