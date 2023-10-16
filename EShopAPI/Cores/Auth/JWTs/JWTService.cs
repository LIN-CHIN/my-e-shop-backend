using EShopAPI.Cores.MapRolePermissions.DTOs;
using EShopAPI.Cores.MapUserRoles;
using EShopAPI.Cores.MapUserRoles.Services;
using EShopAPI.Cores.ShopUsers;
using EShopAPI.Settings;
using EShopCores.Errors;
using EShopCores.Extensions;
using EShopCores.Responses;
using Jose;
using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Text.Json;

namespace EShopAPI.Cores.Auth.JWTs
{
    /// <summary>
    /// JWT Service
    /// </summary>
    public class JwtService : IJwtService
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
        public JwtService(JwtTokenSettings jwtTokenSettings, IMapUserRoleService mapUserRoleService)
        {
            _jwtTokenSettings = jwtTokenSettings;
            _mapUserRoleService = mapUserRoleService;
        }

        ///<inheritdoc/>
        public async Task<string> GenerateAccessTokenAsync(ShopUser shopUser)
        {
            //查詢該user的角色>權限
            IList<MapUserRole> mapUserRoles = await _mapUserRoleService.GetByUserId(shopUser.Id)
                .Include(user => user.ShopRole!)
                    .ThenInclude(role => role.MapRolePermissions!)
                    .ThenInclude(map => map.ShopPermission!)
                .ToListAsync();

            //組權限清單
            IList<MapRolePermissionDto?> shopPermissions = 
                mapUserRoles.SelectMany(m => m.ShopRole!.MapRolePermissions!)
                    .Select(map => MapRolePermissionDto.Parse(map))
                    .ToList();

            return GetToken(shopUser, AccessTokenExpireTime, shopPermissions);
        }

        ///<inheritdoc/>
        public string GenerateRefreshToken(ShopUser shopUser)
        {
            return GetToken(shopUser, RefreshTokenExpireTime);
        }

        ///<inheritdoc/>
        public JwtPayload DecryptToken(string token)
        {
            //remove prefix 
            token = token.Replace("Bearer ", "");

            string json = JWT.Decode(token, Encoding.UTF8.GetBytes(_jwtTokenSettings.SignKey), JwsAlgorithm.HS256);
            JwtPayload? payload = JsonSerializer.Deserialize<JwtPayload>(json);
            if (payload == null) 
            {
                throw new EShopException(ResponseCodeType.InvalidToken, "payload為null，Token解析失敗");
            }

            if (payload.Expiration < DateTime.UtcNow.GetUnixTimestampSecond()) 
            {
                throw new EShopException(ResponseCodeType.TokenOverDue, "token已經過期");
            }

            return payload;
        }

        /// <summary>
        /// 取得Token
        /// </summary>
        /// <param name="shopUser">使用者資訊</param>
        /// <param name="expireTime">到期時間</param>
        /// <param name="mapRolePermissions">角色與權限關係的列表</param>
        /// <returns></returns>
        private string GetToken(ShopUser shopUser, int expireTime, IList<MapRolePermissionDto?>? mapRolePermissions = null) 
        {
            DateTime iat = DateTime.Now;
            DateTime exp = iat.AddSeconds(expireTime);

            var payload = new JwtPayload
            {
                Subject = shopUser.Number,
                Issuer = _jwtTokenSettings.Issuer,
                IssuedAt = iat.GetUnixTimestampSecond(),
                Expiration = exp.GetUnixTimestampSecond(),
                MapRolePermissions = mapRolePermissions,
                IsAdmin = shopUser.IsAdmin
            };

            string json = JsonSerializer.Serialize(payload);
            string token = JWT.Encode(json, Encoding.UTF8.GetBytes(_jwtTokenSettings.SignKey), JwsAlgorithm.HS256);
            return token;
        }
    }
}
