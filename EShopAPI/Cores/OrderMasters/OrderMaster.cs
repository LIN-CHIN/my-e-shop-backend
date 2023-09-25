using EShopAPI.Cores.DeliveryCategories;
using EShopAPI.Cores.OrderForCompositeDetails;
using EShopAPI.Cores.OrderForProducts;
using EShopAPI.Cores.PaymentCategories;
using EShopAPI.Cores.ShopUsers;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EShopAPI.Cores.OrderMasters
{
    /// <summary>
    /// 訂單主檔
    /// </summary>
    [Table("order_master", Schema = "eshop")]
    [Comment("訂單主檔")]
    public class OrderMaster : EShopObject
    {
        /// <summary>
        /// 訂單編號
        /// </summary>
        [Required]
        [Column("number", TypeName = "varchar(50)")]
        [Comment("訂單編號")]
        [StringLength(50)]
        public string Number { get; set; } = null!;

        /// <summary>
        /// 使用者id
        /// </summary>
        [Required]
        [Column("user_id")]
        [Comment("使用者id")]
        [ForeignKey("ShopUser")]
        public long UserId { get; set; }

        /// <summary>
        /// 物流類型id
        /// </summary>
        [Required]
        [Column("delivery_category_id")]
        [Comment("物流類型id")]
        [ForeignKey("DeliveryCategory")]
        public long DeliveryCategoryId { get; set; }

        /// <summary>
        /// 支付類型id
        /// </summary>
        [Required]
        [Column("payment_category_id")]
        [Comment("支付類型id")]
        [ForeignKey("PaymentCategory")]
        public long PaymentCategoryId { get; set; }

        /// <summary>
        /// 是否為組合產品
        /// </summary>
        /// <remarks>
        /// true = 是組合產品
        /// false = 不是組合產品
        /// </remarks>
        [Required]
        [Column("is_composite_product")]
        [Comment("是否為組合產品, true = 是組合產品 , false = 不是組合產品")]
        public int IsCompositeProduct { get; set; }

        /// <summary>
        /// 是否已付款
        /// </summary>
        /// <remarks>
        [Required]
        [Column("is_pay")]
        [Comment("是否已付款")]
        public int IsPay { get; set; }

        /// <summary>
        /// 訂單狀態
        /// </summary>
        [Required]
        [Column("status")]
        [Comment("訂單狀態")]
        public int Status { get; set; }

        /// <summary>
        /// 使用者實體
        /// </summary>
        public ShopUser? ShopUser { get; set; }

        /// <summary>
        /// 物流類型實體
        /// </summary>
        public DeliveryCategory? DeliveryCategory { get; set; }

        /// <summary>
        /// 支付類型實體
        /// </summary>
        public PaymentCategory? PaymentCategory { get; set; }

        /// <summary>
        /// 訂單 (針對組合產品detail)的實體清單
        /// </summary>
        public ICollection<OrderForCompositeDetail>? OrderForCompositeDetails { get; set; }

        /// <summary>
        /// 訂單 (針對非組合產品)的實體清單
        /// </summary>
        public ICollection<OrderForProduct>? OrderForProducts { get; set; }
    }
}
