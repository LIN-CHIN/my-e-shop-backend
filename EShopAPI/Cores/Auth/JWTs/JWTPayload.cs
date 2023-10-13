using EShopAPI.Common;
using EShopAPI.Cores.ShopActions;

namespace EShopAPI.Cores.Auth.JWTs
{
    /// <summary>
    /// JWT payload
    /// </summary>
    public class JwtPayload : JwtBasePayload
    {
        /// <summary>
        /// 是否為管理員
        /// </summary>
        public bool IsAdmin { get; set; }

        /// <summary>
        /// 商店功能清單
        /// </summary>
        public IList<ShopAction>? ShopActions { get; set; } = new List<ShopAction>();

        /// <summary>
        /// 設定登入者資料
        /// </summary>
        /// <param name="loginUserData">要設定資料的實體</param>
        /// <returns></returns>
        public void SetLoginUserData(LoginUserData loginUserData) 
        {
            loginUserData.UserNumber = Subject;
            loginUserData.IsAdmin = IsAdmin;
            loginUserData.ShopActions = ShopActions;
        }
    }
}
