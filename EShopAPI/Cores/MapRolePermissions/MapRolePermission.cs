using EShopAPI.Cores.ShopPermissions;
using EShopAPI.Cores.ShopRoles;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EShopAPI.Cores.MapRolePermissions
{
    /// <summary>
    /// 角色與權限關聯的實體
    /// </summary>
    [Table("map_role_permission", Schema = "eshop")]
    [Comment("角色與權限關聯的實體")]
    public class MapRolePermission : EShopObject
    {
        /// <summary>
        /// 角色id
        /// </summary>
        [Required]
        [Column("role_id")]
        [Comment("角色id")]
        [ForeignKey("ShopRole")]
        public long RoleId { get; set; }

        /// <summary>
        /// 權限id
        /// </summary>
        [Required]
        [Column("permission_id")]
        [Comment("權限id")]
        [ForeignKey("ShopPermission")]
        public long PermissionId { get; set; }

        /// <summary>
        /// 商店角色實體
        /// </summary>
        public ShopRole? ShopRole { get; set; } 

        /// <summary>
        /// 商店權限實體
        /// </summary>
        public ShopPermission? ShopPermission { get; set; } 
    }
}
