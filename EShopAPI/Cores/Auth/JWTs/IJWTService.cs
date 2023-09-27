using EShopAPI.Cores.ShopUsers;

namespace EShopAPI.Cores.Auth.JWTs
{
    /// <summary>
    /// JWT Service Interface
    /// </summary>
    public interface IJWTService
    {
        /// <summary>
        /// 產生Token
        /// </summary>
        /// <param name="shopUser">使用者實體</param>
        /// <returns></returns>
        Task<string> GenerateAccessTokenAsync(ShopUser shopUser);

        /// <summary>
        /// 產生Refresh Token
        /// </summary>
        /// <param name="shopUser">使用者實體</param>
        /// <returns></returns>
        string GenerateRefreshToken(ShopUser shopUser);

    }
}
