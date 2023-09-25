using EShopAPI.Cores.MapRolePermissions;
using EShopAPI.Cores.MapUserRoles;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EShopAPI.Cores.ShopRoles
{
    /// <summary>
    /// 商店角色實體
    /// </summary>
    [Table("shop_role", Schema = "eshop")]
    [Comment("商店角色實體")]
    public class ShopRole : EShopObject
    {
        /// <summary>
        /// 角色代碼
        /// </summary>
        [Required]
        [Column("number", TypeName = "varchar(50)")]
        [Comment("角色代碼")]
        [StringLength(50)]
        public string Number { get; set; } = null!;

        /// <summary>
        /// 使用者名稱
        /// </summary>
        [Required]
        [Column("name", TypeName = "varchar(50)")]
        [Comment("角色名稱")]
        [StringLength(50)]
        public string Name { get; set; } = null!;

        /// <summary>
        /// 使用者與角色的關聯
        /// </summary>
        public ICollection<MapUserRole>? MapUserRoles { get; set; }

        /// <summary>
        /// 角色與權限的關聯
        /// </summary>
        public ICollection<MapRolePermission>? MapRolePermissions { get; set; }
    }
}
