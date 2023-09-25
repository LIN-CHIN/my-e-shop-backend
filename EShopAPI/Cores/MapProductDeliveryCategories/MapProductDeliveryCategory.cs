using EShopAPI.Cores.DeliveryCategories;
using EShopAPI.Cores.ProductMasters;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EShopAPI.Cores.MapProductDeliveryCategorys
{
    /// <summary>
    /// 產品主表與物流種類關係的實體
    /// </summary>
    [Table("map_product_delivery_category", Schema = "eshop")]
    [Comment("產品主表與物流種類關係的實體")]
    public class MapProductDeliveryCategory : EShopObject
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
        [Column("delivery_category_id")]
        [Comment("物流種類id")]
        [ForeignKey("DeliveryCategory")]
        public long DeliveryCategoryId { get; set; }

        /// <summary>
        /// 組合產品主表實體
        /// </summary>
        public ProductMaster? ProductMaster { get; set; } 

        /// <summary>
        /// 物流種類的實體
        /// </summary>
        public DeliveryCategory? DeliveryCategory { get; set; }
    }
}
