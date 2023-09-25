using EShopAPI.Cores.DeliveryPreferences;
using EShopAPI.Cores.MapCompositeProductDeliveries;
using EShopAPI.Cores.MapProductDeliveryCategorys;
using EShopAPI.Cores.OrderMasters;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EShopAPI.Cores.DeliveryCategories
{
    /// <summary>
    /// 物流種類
    /// </summary>
    [Table("delivery_category", Schema = "eshop")]
    [Comment("物流種類")]
    public class DeliveryCategory : EShopObject
    {
        /// <summary>
        /// 物流種類代碼
        /// </summary>
        [Required]
        [Column("number", TypeName = "varchar(50)")]
        [Comment("物流種類代碼")]
        [StringLength(50)]
        public string Number { get; set; } = null!;

        /// <summary>
        /// 物流種類名稱
        /// </summary>
        [Required]
        [Column("name", TypeName = "varchar(50)")]
        [Comment("物流種類名稱")]
        [StringLength(50)]
        public string Name { get; set; } = null!;

        /// <summary>
        /// 組合產品與物流種類關聯的實體清單
        /// </summary>
        public ICollection<MapCompositeProductDelivery>? MapCompositeProductDeliveries { get; set; }

        /// <summary>
        /// 產品主表與物流種類關聯的實體清單
        /// </summary>
        public ICollection<MapProductDeliveryCategory>? MapProductDeliveryCategories { get; set; }

        /// <summary>
        /// 物流偏好實體清單
        /// </summary>
        public ICollection<DeliveryPreference>? DeliveryPreferences { get; set; }

        /// <summary>
        /// 使用者偏好實體清單
        /// </summary>
        public ICollection<OrderMaster>? OrderMasters { get; set; }
    }
}
