using EShopAPI.Cores.ProductCategories;
using EShopAPI.Cores.ProductMasters;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EShopAPI.Cores.MapProductCategories
{
    /// <summary>
    /// 產品主表與產品類別關聯的實體
    /// </summary>
    [Table("map_product_category", Schema = "eshop")]
    [Comment("產品主表與產品類別關聯的實體")]
    public class MapProductCategory : EShopObject
    {
        /// <summary>
        /// 組合產品主表id
        /// </summary>
        [Required]
        [Column("product_master_id")]
        [Comment("組合產品主表id")]
        [ForeignKey("ProductMaster")]
        public long ProductMasterId { get; set; }

        /// <summary>
        /// 物流種類id
        /// </summary>
        [Required]
        [Column("product_category_id")]
        [Comment("產品種類id")]
        [ForeignKey("ProductCategory")]
        public long ProductCategoryId { get; set; }

        /// <summary>
        /// 組合產品主表實體
        /// </summary>
        public ProductMaster? ProductMaster { get; set; }

        /// <summary>
        /// 物流種類的實體
        /// </summary>
        public ProductCategory? ProductCategory { get; set; }
    }
}
