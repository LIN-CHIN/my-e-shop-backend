using EShopAPI.Cores.CompositeProducts;
using EShopAPI.Cores.EShopUnits;
using EShopAPI.Cores.ShopInventories;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EShopAPI.Cores.CompositeProductItems
{
    /// <summary>
    /// 組合產品的項目
    /// </summary>
    [Table("composite_product_item", Schema = "eshop")]
    [Comment("組合產品實際的內容物")]
    public class CompositeProductItem : EShopObject
    {
        /// <summary>
        /// 組合產品detail的id
        /// </summary>
        [Required]
        [Column("composite_product_id")]
        [Comment("組合產品detail的id")]
        [ForeignKey("CompositeProduct")]
        public long CompositeProductId { get; set; }

        /// <summary>
        /// 庫存id
        /// </summary>
        [Required]
        [Column("shop_inventory_id")]
        [Comment("庫存id")]
        [ForeignKey("ShopInventory")]
        public long ShopInventoryId { get; set; }

        /// <summary>
        /// 單筆價格
        /// </summary>
        [Required]
        [Column("price")]
        [Comment("單筆價格")]
        public int Price { get; set; }

        /// <summary>
        /// 數量
        /// </summary>
        [Required]
        [Column("count")]
        [Comment("數量")]
        public int Count { get; set; }

        /// <summary>
        /// 是否總是特價
        /// </summary>
        [Required]
        [Column("is_always_sale")]
        [Comment("是否總是特價")]
        public bool IsAlwaysSale { get; set; }

        /// <summary>
        /// 折扣數
        /// </summary>
        [Column("discount")]
        [Comment("折扣數")]
        public double Discount { get; set; }

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
        /// 單位
        /// </summary>
        [Required]
        [Column("eshop_unit_id")]
        [Comment("單位")]
        [ForeignKey("EShopUnit")]
        public long EshopUnitId { get; set; }

        /// <summary>
        /// 組合產品Detail的實體
        /// </summary>
        public CompositeProduct? CompositeProduct { get; set;}

        /// <summary>
        /// 商店單位的實體
        /// </summary>
        public EShopUnit? EShopUnit { get; set; }

        /// <summary>
        /// 商品庫存
        /// </summary>
        public ShopInventory? ShopInventory { get; set; }

    }
}
