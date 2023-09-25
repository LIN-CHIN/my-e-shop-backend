using EShopAPI.Cores.DeliveryCategories;
using EShopAPI.Cores.ShopUsers;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EShopAPI.Cores.DeliveryPreferences
{
    /// <summary>
    /// 物流偏好實體
    /// </summary>
    [Table("delivery_preference", Schema = "eshop")]
    [Comment("物流偏好實體")]
    public class DeliveryPreference : EShopObject
    {
        /// <summary>
        /// 使用者id
        /// </summary>
        [Required]
        [Column("user_id")]
        [Comment("使用者id")]
        public long UserId { get; set; }

        /// <summary>
        /// 物流類型id
        /// </summary>
        [Required]
        [Column("delivery_category_id")]
        [Comment("物流類型id")]
        public long DeliveryCategoryId { get; set; }

        /// <summary>
        /// 是否為主要的運送方式
        /// </summary>
        [Required]
        [Column("is_primary")]
        [Comment("是否為主要的運送方式")]
        public bool IsPrimary { get; set; }

        /// <summary>
        /// 地址
        /// </summary>
        [Column("address", TypeName = "varchar(100)")]
        [Comment("地址")]
        [StringLength(100)]
        public string? Address { get; set; }

        /// <summary>
        /// 使用者實體
        /// </summary>
        public ShopUser? ShopUser { get; set; }

        /// <summary>
        /// 物流類型實體
        /// </summary>
        public DeliveryCategory? DeliveryCategory { get; set; }
    }
}
