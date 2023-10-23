using EShopAPI.Cores.RecordOrderMasters;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EShopAPI.Cores.RecordOrderProducts
{
    /// <summary>
    /// 訂單紀錄(針對產品)
    /// </summary>
    [Table("record_order_product", Schema = "eshop")]
    [Comment("訂單紀錄(針對非組合產品)")]
    public class RecordOrderProduct : EShopObject
    {
        /// <summary>
        /// 訂單紀錄主檔id
        /// </summary>
        [Required]
        [Column("master_id")]
        [Comment("訂單紀錄主檔id")]
        [ForeignKey("RecordOrderMaster")]
        public long MasterId { get; set; }

        /// <summary>
        /// 產品代碼
        /// </summary>
        [Required]
        [Column("product_number", TypeName = "varchar(50)")]
        [Comment("產品代碼")]
        [StringLength(50)]
        public string ProductNumber { get; set; } = null!;

        /// <summary>
        /// 產品名稱
        /// </summary>
        [Required]
        [Column("product_name", TypeName = "varchar(50)")]
        [Comment("產品名稱")]
        [StringLength(50)]
        public string ProductName { get; set; } = null!;

        /// <summary>
        /// 供應商
        /// </summary>
        [Column("supplier", TypeName = "varchar(50)")]
        [Comment("供應商")]
        [StringLength(50)]
        public string? Supplier { get; set; }

        /// <summary>
        /// 品牌
        /// </summary>
        [Column("brand", TypeName = "varchar(50)")]
        [Comment("品牌")]
        [StringLength(50)]
        public string? Brand { get; set; }

        /// <summary>
        /// 數量
        /// </summary>
        [Required]
        [Column("count")]
        [Comment("數量")]
        public int Count { get; set; }

        /// <summary>
        /// 單筆價格(原價)
        /// </summary>
        [Required]
        [Column("price")]
        [Comment("單筆價格(原價)")]
        public int Price { get; set; }

        /// <summary>
        /// 是否特價
        /// </summary>
        [Required]
        [Column("is_sale")]
        [Comment("是否特價")]
        public bool IsSale { get; set; }

        /// <summary>
        /// 折扣數
        /// </summary>
        [Column("discount")]
        [Comment("折扣數")]
        public double? Discount { get; set; }

        /// <summary>
        /// 訂單主檔實體
        /// </summary>
        public RecordOrderMaster? RecordOrderMaster { get; set; }
    }
}
