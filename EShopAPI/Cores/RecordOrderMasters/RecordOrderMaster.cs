using EShopAPI.Cores.RecordOrderForCompositeDetails;
using EShopAPI.Cores.RecordOrderForProducts;
using EShopAPI.Cores.ShopUsers;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EShopAPI.Cores.RecordOrderMasters
{
    /// <summary>
    /// 訂單主檔紀錄
    /// </summary>
    [Table("record_order_master", Schema = "eshop")]
    [Comment("訂單主檔紀錄")]
    public class RecordOrderMaster : EShopObject
    {
        /// <summary>
        /// 訂單編號
        /// </summary>
        [Required]
        [Column("order_number", TypeName = "varchar(50)")]
        [Comment("訂單編號")]
        [StringLength(50)]
        public string OrderNumber { get; set; } = null!;

        /// <summary>
        /// 使用者id
        /// </summary>
        [Required]
        [Column("user_id")]
        [Comment("使用者id")]
        [ForeignKey("ShopUser")]
        public long UserId { get; set; }

        /// <summary>
        /// 物流類型代碼
        /// </summary>
        [Required]
        [Column("delivery_category_number", TypeName = "varchar(50)")]
        [Comment("物流類型代碼")]
        [StringLength(50)]
        public string DeliveryCategoryNumber { get; set; } = null!;

        /// <summary>
        /// 物流類型名稱
        /// </summary>
        [Required]
        [Column("delivery_category_name", TypeName = "varchar(50)")]
        [Comment("物流類型名稱")]
        [StringLength(50)]
        public string DeliveryCategoryName { get; set; } = null!;

        /// <summary>
        /// 支付類型代碼
        /// </summary>
        [Required]
        [Column("payment_category_number", TypeName = "varchar(50)")]
        [Comment("支付類型代碼")]
        [StringLength(50)]
        public string PaymentCategoryNumber { get; set; } = null!;

        /// <summary>
        /// 支付類型代碼
        /// </summary>
        [Required]
        [Column("payment_category_name", TypeName = "varchar(50)")]
        [Comment("支付類型代碼")]
        [StringLength(50)]
        public string PaymentCategoryName { get; set; } = null!;

        /// <summary>
        /// 是否為組合產品
        /// </summary>
        [Required]
        [Column("is_composite_product")]
        [Comment("是否為組合產品")]
        public bool IsCompositeProduct { get; set; }

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
        /// 訂單紀錄(針對組合產品detail)的實體清單
        /// </summary>
        public ICollection<RecordOrderForCompositeDetail>? RecordOrderForCompositeDetails { get; set; }

        /// <summary>
        /// 訂單紀錄(針對非組合產品)的實體清單
        /// </summary>
        public ICollection<RecordOrderForProduct>? RecordOrderForProducts { get; set; }
    }
}
