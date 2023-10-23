using EShopAPI.Cores.CompositeProductItems;
using EShopAPI.Cores.EShopUnits;
using EShopAPI.Cores.MapCompositeProductDeliveries;
using EShopAPI.Cores.ShopInventories;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EShopAPI.Cores.CompositeProducts
{
    /// <summary>
    /// 要販售的組合產品
    /// </summary>
    [Table("composite_product", Schema = "eshop")]
    [Comment("要販售的組合產品")]
    public class CompositeProduct : EShopObject
    {
        /// <summary>
        /// 庫存id
        /// </summary>
        [Required]
        [Column("shop_inventory_id")]
        [Comment("庫存id")]
        [ForeignKey("ShopInventory")]
        public long ShopInventoryId { get; set; }

        /// <summary>
        /// 商店單位id
        /// </summary>
        [Required]
        [Column("eshop_unit_id")]
        [Comment("商店單位id")]
        [ForeignKey("EShopUnit")]
        public long EShopUnitId { get; set; }

        /// <summary>
        /// 是否可以使用優惠券
        /// </summary>
        [Required]
        [Column("is_use_coupon")]
        [Comment("是否可以使用優惠券")]
        public bool IsUseCoupon { get; set; }

        /// <summary>
        /// 商店單位
        /// </summary>
        public EShopUnit? EShopUnit { get; set; }

        /// <summary>
        /// 組合產品項目清單
        /// </summary>
        public ICollection<CompositeProductItem>? CompositeProductItems { get; set; }

        /// <summary>
        /// 商店庫存實體
        /// </summary>
        public ShopInventory? ShopInventory { get; set; }

        /// <summary>
        /// 組合產品項目清單
        /// </summary>
        public ICollection<MapCompositeProductDelivery>? MapCompositeProductDeliveries { get; set; }
    }
}
