using EShopAPI.Cores.OrderForCompositeItems;
using EShopAPI.Cores.OrderMasters;
using EShopAPI.Cores.ShopInventories;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EShopAPI.Cores.OrderCompositeProducts
{
    /// <summary>
    /// 訂單 (針對組合產品)
    /// </summary>
    [Table("order_composite_product", Schema = "eshop")]
    [Comment("訂單 (針對組合產品)")]
    public class OrderCompositeProduct : EShopObject
    {
        /// <summary>
        /// 訂單主檔id
        /// </summary>
        [Required]
        [Column("master_id")]
        [Comment("訂單主檔id")]
        [ForeignKey("OrderMaster")]
        public long MasterId { get; set; }

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
        /// 訂單主檔實體
        /// </summary>
        public OrderMaster? OrderMaster { get; set; }

        /// <summary>
        /// 商店產品庫存實體
        /// </summary>
        public ShopInventory? ShopInventory { get; set; }

        /// <summary>
        /// 訂單 (針對組合產品item)實體清單
        /// </summary>
        public ICollection<OrderCompositeProductItem>? OrderCompositeProductItems { get; set; }
    }
}
