using EShopAPI.Common;
using EShopAPI.Cores.MapRolePermissions.DTOs;

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
        /// 權限清單
        /// </summary>
        public IList<MapRolePermissionDto?>? MapRolePermissions { get; set; }
    }
}
