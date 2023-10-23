using EShopAPI.Cores.CompositeProductItems;
using EShopAPI.Cores.CompositeProducts;
using EShopAPI.Cores.Products;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EShopAPI.Cores.EShopUnits
{
    /// <summary>
    /// eShop單位總表
    /// </summary>
    [Table("eshop_unit", Schema = "eshop")]
    [Comment("eShop單位總表")]
    public class EShopUnit : EShopObject
    {
        /// <summary>
        /// 單位代碼
        /// </summary>
        [Required]
        [Column("number", TypeName = "varchar(50)")]
        [Comment("單位代碼")]
        [StringLength(50)]
        public string Number { get; set; } = null!;

        /// <summary>
        /// 單位名稱
        /// </summary>
        [Required]
        [Column("name", TypeName = "varchar(20)")]
        [Comment("單位名稱")]
        [StringLength(20)]
        public string Name { get; set; } = null!;

        /// <summary>
        /// 是否啟用
        /// </summary>
        [Required]
        [Column("is_enable")]
        [Comment("是否啟用")]
        public bool IsEnable { get; set; }

        /// <summary>
        /// 是否為系統預設
        /// </summary>
        [Required]
        [Column("is_system_default")]
        [Comment("是否為系統預設")]
        public bool IsSystemDefault { get; set; }

        /// <summary>
        /// 產品細項清單
        /// </summary>
        public ICollection<Product>? Product { get; set; }

        /// <summary>
        /// 組合產品細項清單
        /// </summary>
        public ICollection<CompositeProduct>? CompositeProduct { get; set; }

        /// <summary>
        /// 組合產品Detail產品項目的清單
        /// </summary>
        public ICollection<CompositeProductItem>? CompositeProductItems { get; set; }
    }
}
