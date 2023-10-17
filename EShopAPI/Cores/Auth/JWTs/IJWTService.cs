using EShopAPI.Cores.ShopUsers;

namespace EShopAPI.Cores.Auth.JWTs
{
    /// <summary>
    /// JWT Service Interface
    /// </summary>
    public interface IJwtService
    {
        /// <summary>
        /// 產生Token
        /// </summary>
        /// <param name="shopUser">使用者實體</param>
        /// <returns></returns>
        string GenerateAccessToken(ShopUser shopUser);

        /// <summary>
        /// 產生Refresh Token
        /// </summary>
        /// <param name="shopUser">使用者實體</param>
        /// <returns></returns>
        string GenerateRefreshToken(ShopUser shopUser);

        /// <summary>
        /// 解析Token
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        JwtPayload DecryptToken(string token);
    }
}
