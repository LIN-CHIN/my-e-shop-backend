using EShopAPI.Cores.MapProductCategories;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EShopAPI.Cores.ProductCategories
{
    /// <summary>
    /// 產品類別
    /// </summary>
    [Table("product_category", Schema = "eshop")]
    [Comment("產品類別")]
    public class ProductCategory : EShopObject
    {
        /// <summary>
        /// 產品類別代碼
        /// </summary>
        [Required]
        [Column("number", TypeName = "varchar(50)")]
        [Comment("產品類別代碼")]
        [StringLength(50)]
        public string Number { get; set; } = null!;

        /// <summary>
        /// 產品類別名稱
        /// </summary>
        [Required]
        [Column("name", TypeName = "varchar(50)")]
        [Comment("產品類別名稱")]
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
        /// 產品主表與產品類別關聯的實體清單
        /// </summary>
        public ICollection<MapProductCategory>? MapProductCategories { get; set; }
    }
}
