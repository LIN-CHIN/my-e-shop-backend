using EShopAPI.Cores.MapPermissionActions;
using EShopAPI.Cores.MapRolePermissions;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EShopAPI.Cores.ShopPermissions
{
    /// <summary>
    /// 商店權限實體
    /// </summary>
    [Table("shop_permission", Schema = "eshop")]
    [Comment("商店權限實體")]
    public class ShopPermission : EShopObject
    {
        /// <summary>
        /// 權限代碼
        /// </summary>
        [Required]
        [Column("number", TypeName = "varchar(50)")]
        [Comment("權限代碼")]
        [StringLength(50)]
        public string Number { get; set; } = null!;

        /// <summary>
        /// 權限名稱
        /// </summary>
        [Required]
        [Column("name", TypeName = "varchar(50)")]
        [Comment("權限名稱")]
        [StringLength(50)]
        public string Name { get; set; } = null!;

        /// <summary>
        /// 是否啟用
        /// </summary>
        [Required]
        [Column("is_enable")]
        [Comment("是否啟用")]
        public bool IsEnable { get; set; }

        /// <summary>
        /// 角色與權限的關聯
        /// </summary>
        public ICollection<MapRolePermission>? MapRolePermissions { get; set; } 

        /// <summary>
        /// 權限與功能的關聯
        /// </summary>
        public ICollection<MapPermissionAction>? MapPermissionActions { get; set; }
    }
}
