using EShopAPI.Cores.ShopActions;

namespace EShopAPI.Common
{
    /// <summary>
    /// 登入者的資訊
    /// </summary>
    public class LoginUserData
    {
        /// <summary>
        /// 使用者帳號
        /// </summary>
        public string UserNumber { get; set; } = null!;

        /// <summary>
        /// 是否為管理員
        /// </summary>
        public bool IsAdmin { get; set; }

        /// <summary>
        /// 商店功能清單
        /// </summary>
        public IList<ShopAction>? ShopActions { get; set; } = new List<ShopAction>();
    }
}
