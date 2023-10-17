using EShopAPI.Cores.Auth.JWTs;
using EShopAPI.Cores.MapRolePermissions.DTOs;
using EShopAPI.Cores.ShopActions;
using EShopAPI.Cores.ShopPermissions;
using EShopAPI.Cores.ShopPermissions.DTOs;

namespace EShopAPI.Common
{
    /// <summary>
    /// 登入者的資訊
    /// </summary>
    public class LoginUserData
    {
        /// <summary>
        /// 使用者id
        /// </summary>
        public long UserId { get; set; } 

        /// <summary>
        /// 使用者帳號
        /// </summary>
        public string UserNumber { get; set; } = null!;

        /// <summary>
        /// 是否為管理員
        /// </summary>
        public bool IsAdmin { get; set; }

        /// <summary>
        /// 設定登入者資料
        /// </summary>
        /// <param name="jwtPayload">解析token取得的payload</param>
        /// <returns></returns>
        public void SetLoginUserData(JwtPayload jwtPayload)
        {
            UserId = jwtPayload.UserId;
            UserNumber = jwtPayload.Subject;
            IsAdmin = jwtPayload.IsAdmin;
        }
    }
}
