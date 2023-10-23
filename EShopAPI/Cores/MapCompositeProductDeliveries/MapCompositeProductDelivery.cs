using EShopAPI.Cores.DeliveryCategories;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EShopAPI.Cores.CompositeProducts;

namespace EShopAPI.Cores.MapCompositeProductDeliveries
{
    /// <summary>
    /// 組合產品主表與物流種類關聯的實體
    /// </summary>
    [Table("map_composite_product_delivery", Schema = "eshop")]
    [Comment("組合產品與物流種類關聯的實體")]
    public class MapCompositeProductDelivery : EShopObject
    {
        /// <summary>
        /// 組合產品主表id
        /// </summary>
        [Required]
        [Column("composite_product_id")]
        [Comment("組合產品id")]
        [ForeignKey("CompositeProduct")]
        public long CompositeProductId { get; set; }

        /// <summary>
        /// 物流種類id
        /// </summary>
        [Required]
        [Column("delivery_category_id")]
        [Comment("物流種類id")]
        [ForeignKey("DeliveryCategory")]
        public long DeliveryCategoryId { get; set; }

        /// <summary>
        /// 組合產品實體
        /// </summary>
        public CompositeProduct? CompositeProduct { get; set; }

        /// <summary>
        /// 物流種類的實體
        /// </summary>
        public DeliveryCategory? DeliveryCategory { get; set; }
    }
}
