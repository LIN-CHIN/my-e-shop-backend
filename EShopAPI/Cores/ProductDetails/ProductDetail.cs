using EShopAPI.Cores.CompositeProductDetails;
using EShopAPI.Cores.EShopUnits;
using EShopAPI.Cores.ProductMasters;
using EShopAPI.Cores.ShopInventories;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;

namespace EShopAPI.Cores.ProductDetails
{
    /// <summary>
    /// 產品子檔, 產品的細節、變種
    /// </summary>
    [Table("product_detail", Schema = "eshop")]
    [Comment("產品子檔, 產品的細節、變種")]
    public class ProductDetail : EShopObject
    {
        /// <summary>
        /// 產品主檔id
        /// </summary>
        [Required]
        [Column("master_id")]
        [Comment("產品主檔id")]
        [ForeignKey("ProductMaster")]
        public long MasterId { get; set; }

        /// <summary>
        /// 庫存id
        /// </summary>
        [Required]
        [Column("shop_inventory_id")]
        [Comment("庫存id")]
        [ForeignKey("ShopInventory")]
        public long ShopInventoryId { get; set; }

        /// <summary>
        /// 價格
        /// </summary>
        [Required]
        [Column("price")]
        [Comment("價格")]
        public int Price { get; set; }

        /// <summary>
        /// 商店單位id
        /// </summary>
        [Required]
        [Column("eshop_unit_id")]
        [Comment("商店單位id")]
        [ForeignKey("EShopUnit")]
        public long EShopUnitId { get; set; }

        /// <summary>
        /// 產品狀態
        /// </summary>
        /// <remarks>
        /// 暫無想法，保留欄位
        /// </remarks>
        [Column("status")]
        [Comment("產品狀態, 暫無想法，保留欄位")]
        public int? Status { get; set; }

        /// <summary>
        /// 是否總是特價
        /// </summary>
        [Required]
        [Column("always_sale")]
        [Comment("是否總是特價")]
        public bool AlwaysSale { get; set; }
        
        /// <summary>
        /// 折扣數
        /// </summary>
        [Column("discount")]
        [Comment("折扣數")]
        public double? Discount { get; set; }

        /// <summary>
        /// 特價起始日期
        /// </summary>
        [Column("sale_start_date")]
        [Comment("特價起始日期")]
        public long? SaleStartDate { get; set; }

        /// <summary>
        /// 特價結束日期
        /// </summary>
        [Column("sale_end_date")]
        [Comment("特價結束日期")]
        public long? SaleEndDate { get; set; }

        /// <summary>
        /// 是否啟用
        /// </summary>
        [Required]
        [Column("is_enable")]
        [Comment("是否啟用")]
        public bool IsEnable { get; set; }

        /// <summary>
        /// 變種屬性
        /// </summary>
        /// <remarks>
        /// 這個產品變種屬性有哪一些值? 包含產品(細項)自己本身的屬性值
        /// ex: color:[red, blue], size[S,M]
        /// </remarks>
        [Column("variant_attribute", TypeName = "jsonb")]
        [Comment("變種屬性, 這個產品變種屬性有哪一些值? 包含產品(細項)自己本身的屬性值 ex: color:[red, blue], size[S,M]")]
        public JsonDocument? VariantAttribute { get; set; }

        /// <summary>
        /// 產品主檔
        /// </summary>
        public ProductMaster? ProductMaster { get; set; }

        /// <summary>
        /// 單位
        /// </summary>
        public EShopUnit? EShopUnit { get; set; }

        /// <summary>
        /// 商品庫存
        /// </summary>
        public ShopInventory? ShopInventory { get; set; }
    }
}
