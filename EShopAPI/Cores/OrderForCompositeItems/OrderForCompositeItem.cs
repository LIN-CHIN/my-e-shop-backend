using EShopAPI.Cores.OrderForCompositeDetails;
using EShopAPI.Cores.ShopInventories;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EShopAPI.Cores.OrderForCompositeItems
{
    /// <summary>
    /// 訂單 (針對組合產品item)
    /// </summary>
    [Table("order_for_composite_item", Schema = "eshop")]
    [Comment("訂單 (針對組合產品item)")]
    public class OrderForCompositeItem : EShopObject
    {
        /// <summary>
        /// 訂單主檔id
        /// </summary>
        [Required]
        [Column("detail_id")]
        [Comment("訂單(針對組合產品detail)的id")]
        [ForeignKey("OrderForCompositeDetail")]
        public long DetailId { get; set; }

        /// <summary>
        /// 商店產品庫存id
        /// </summary>
        [Required]
        [Column("shop_inventory_id")]
        [Comment("商店產品庫存id")]
        [ForeignKey("ShopInventory")]
        public long ShopInventoryId { get; set; }

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
        /// 訂單 (針對組合產品detail)的實體
        /// </summary>
        public OrderForCompositeDetail? OrderForCompositeDetail { get; set; }

        /// <summary>
        /// 商店產品庫存實體
        /// </summary>
        public ShopInventory? ShopInventory { get; set; }
    }
}
