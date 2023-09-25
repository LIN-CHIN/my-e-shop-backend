using EShopAPI.Cores.ShopActions;
using EShopAPI.Cores.ShopPermissions;
using EShopAPI.Cores.ShopRoles;
using EShopAPI.Cores.ShopUsers;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EShopAPI.Cores.MapPermissionActions
{
    /// <summary>
    /// 權限與功能的實體
    /// </summary>
    [Table("map_permission_action", Schema = "eshop")]
    [Comment("權限與功能的實體")]
    public class MapPermissionAction : EShopObject
    {
        /// <summary>
        /// 權限id
        /// </summary>
        [Required]
        [Column("permisstion_id")]
        [Comment("權限id")]
        [ForeignKey("ShopPermission")]
        public long PermissionId { get; set; }

        /// <summary>
        /// 功能id
        /// </summary>
        [Required]
        [Column("action_id")]
        [Comment("功能id")]
        [ForeignKey("ShopAction")]
        public long ActionId { get; set; }

        /// <summary>
        /// 權限的實體
        /// </summary>
        public ShopPermission? ShopPermission { get; set; }

        /// <summary>
        /// 功能的實體
        /// </summary>
        public ShopAction? ShopAction { get; set; }
    }
}
