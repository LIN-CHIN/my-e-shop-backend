using EShopAPI.Cores.ShopRoles;
using EShopAPI.Cores.ShopUsers;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EShopAPI.Cores.MapUserRoles
{
    /// <summary>
    /// 使用者與角色關聯的實體
    /// </summary>
    [Table("map_user_role", Schema = "eshop")]
    [Comment("使用者與角色關聯的實體")]
    public class MapUserRole : EShopObject
    {
        /// <summary>
        /// 使用者id
        /// </summary>
        [Required]
        [Column("user_id")]
        [Comment("使用者id")]
        [ForeignKey("ShopUser")]
        public long UserId { get; set; } 

        /// <summary>
        /// 角色id
        /// </summary>
        [Required]
        [Column("role_id")]
        [Comment("角色id")]
        [ForeignKey("ShopRole")]
        public long RoleId { get; set; }

        /// <summary>
        /// 商店使用者的實體
        /// </summary>
        public ShopUser? ShopUser { get; set; }

        /// <summary>
        /// 商店角色的實體
        /// </summary>
        public ShopRole? ShopRole { get; set; }
    }
}
