using EShopAPI.Cores.ShopActions;

namespace EShopAPI.Cores.Auth.JWTs
{
    /// <summary>
    /// JWT payload
    /// </summary>
    public class JwtPayload : JwtBasePayload
    {
        /// <summary>
        /// 商店功能清單
        /// </summary>
        public IList<ShopAction>? ShopActions { get; set; } = new List<ShopAction>();
    }
}
