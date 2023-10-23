using EShopAPI.Cores.ProductCategories;
using EShopAPI.Cores.Products;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EShopAPI.Cores.MapProductCategories
{
    /// <summary>
    /// 產品主表與產品類別關聯的實體
    /// </summary>
    [Table("map_product_category", Schema = "eshop")]
    [Comment("產品與產品類別關聯的實體")]
    public class MapProductCategory : EShopObject
    {
        /// <summary>
        /// 產品主表id
        /// </summary>
        [Required]
        [Column("product_id")]
        [Comment("產品id")]
        [ForeignKey("Product")]
        public long ProductId { get; set; }

        /// <summary>
        /// 物流種類id
        /// </summary>
        [Required]
        [Column("product_category_id")]
        [Comment("產品種類id")]
        [ForeignKey("ProductCategory")]
        public long ProductCategoryId { get; set; }

        /// <summary>
        /// 產品實體
        /// </summary>
        public Product? Product { get; set; }

        /// <summary>
        /// 物流種類的實體
        /// </summary>
        public ProductCategory? ProductCategory { get; set; }
    }
}
