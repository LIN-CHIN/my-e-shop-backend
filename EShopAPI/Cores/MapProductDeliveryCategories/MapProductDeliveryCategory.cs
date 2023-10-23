using EShopAPI.Cores.DeliveryCategories;
using EShopAPI.Cores.Products;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EShopAPI.Cores.MapProductDeliveryCategorys
{
    /// <summary>
    /// 產品與物流種類關係的實體
    /// </summary>
    [Table("map_product_delivery_category", Schema = "eshop")]
    [Comment("產品與物流種類關係的實體")]
    public class MapProductDeliveryCategory : EShopObject
    {
        /// <summary>
        /// 產品id
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
        [Column("delivery_category_id")]
        [Comment("物流種類id")]
        [ForeignKey("DeliveryCategory")]
        public long DeliveryCategoryId { get; set; }

        /// <summary>
        /// 組合產品主表實體
        /// </summary>
        public Product? Product { get; set; } 

        /// <summary>
        /// 物流種類的實體
        /// </summary>
        public DeliveryCategory? DeliveryCategory { get; set; }
    }
}
