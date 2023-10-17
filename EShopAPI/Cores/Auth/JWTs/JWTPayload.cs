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
        /// 使用者id
        /// </summary>
        public long UserId { get; set; }

        /// <summary>
        /// 是否為管理員
        /// </summary>
        public bool IsAdmin { get; set; }
    }
}
