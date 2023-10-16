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
        /// 使用者帳號
        /// </summary>
        public string UserNumber { get; set; } = null!;

        /// <summary>
        /// 是否為管理員
        /// </summary>
        public bool IsAdmin { get; set; }

        /// <summary>
        /// 角色與權限關係的清單
        /// </summary>
        public IList<MapRolePermissionDto?>? MapRolePermissions { get; set; }
    }
}
