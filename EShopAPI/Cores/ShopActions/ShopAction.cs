using EShopAPI.Cores.MapPermissionActions;
using EShopAPI.Cores.MapRolePermissions;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EShopAPI.Cores.ShopActions
{
    /// <summary>
    /// 商店Action(功能)實體
    /// </summary>
    /// <remarks>
    /// 儲存角色權限可以用哪些API (Controller Action)
    /// </remarks>
    [Table("shop_action", Schema = "eshop")]
    [Comment("商店Action(功能)實體, 存角色權限可以用哪些API (Controller Action)")]
    public class ShopAction : EShopObject
    {
        /// <summary>
        /// 功能代碼
        /// </summary>
        [Required]
        [Column("number", TypeName = "varchar(50)")]
        [Comment("功能代碼")]
        [StringLength(50)]
        public string Number { get; set; } = null!;

        /// <summary>
        /// 功能名稱
        /// </summary>
        [Required]
        [Column("name", TypeName = "varchar(50)")]
        [Comment("功能名稱")]
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
        /// 權限與功能關聯的實體
        /// </summary>
        public ICollection<MapPermissionAction>? MapPermissionActions { get; set; }
    }
}
