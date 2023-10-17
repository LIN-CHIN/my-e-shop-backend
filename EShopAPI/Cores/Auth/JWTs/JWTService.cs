using EShopAPI.Cores.ShopUsers;
using EShopAPI.Settings;
using EShopCores.Errors;
using EShopCores.Extensions;
using EShopCores.Responses;
using Jose;
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

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="jwtTokenSettings"></param>
        public JwtService(JwtTokenSettings jwtTokenSettings)
        {
            _jwtTokenSettings = jwtTokenSettings;
        }

        ///<inheritdoc/>
        public string GenerateAccessToken(ShopUser shopUser)
        {
            return GetToken(shopUser, AccessTokenExpireTime);
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
        /// <returns></returns>
        private string GetToken(ShopUser shopUser, int expireTime) 
        {
            DateTime iat = DateTime.Now;
            DateTime exp = iat.AddSeconds(expireTime);

            var payload = new JwtPayload
            {
                Subject = shopUser.Number,
                Issuer = _jwtTokenSettings.Issuer,
                IssuedAt = iat.GetUnixTimestampSecond(),
                Expiration = exp.GetUnixTimestampSecond(),
                IsAdmin = shopUser.IsAdmin,
                UserId = shopUser.Id
            };

            string json = JsonSerializer.Serialize(payload);
            string token = JWT.Encode(json, Encoding.UTF8.GetBytes(_jwtTokenSettings.SignKey), JwsAlgorithm.HS256);
            return token;
        }
    }
}
