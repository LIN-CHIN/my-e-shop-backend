using EShopAPI.Cores.CompositeProductDetails;
using EShopAPI.Cores.CompositeProductItems;
using EShopAPI.Cores.OrderForCompositeDetails;
using EShopAPI.Cores.OrderForCompositeItems;
using EShopAPI.Cores.OrderForProducts;
using EShopAPI.Cores.ProductDetails;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EShopAPI.Cores.ShopInventories
{
    /// <summary>
    /// 商店庫存
    /// </summary>
    [Table("shop_inventory", Schema = "eshop")]
    [Comment("商店庫存")]
    public class ShopInventory : EShopObject
    {
        /// <summary>
        /// 商品代碼
        /// </summary>
        [Required]
        [Column("number", TypeName = "varchar(50)")]
        [Comment("商品代碼")]
        [StringLength(50)]
        public string Number { get; set; } = null!;

        /// <summary>
        /// 商品名稱
        /// </summary>
        [Required]
        [Column("name", TypeName = "varchar(50)")]
        [Comment("商品名稱")]
        [StringLength(50)]
        public string Name { get; set; } = null!;

        /// <summary>
        /// 商品庫存數量
        /// </summary>
        [Required]
        [Column("inventory_quantity")]
        [Comment("商品庫存數量")]
        public int InventoryQuantity { get; set; }

        /// <summary>
        /// 商品庫存警告數
        /// </summary>
        [Required]
        [Column("inventory_alert")]
        [Comment("商品庫存警告數")]
        public int InventoryAlert { get; set; }

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
        /// 是否啟用
        /// </summary>
        [Required]
        [Column("is_enable")]
        [Comment("是否啟用")]
        public bool IsEnable { get; set; }

        /// <summary>
        /// 商品細項
        /// </summary>
        public ProductDetail? ProductDetail { get; set; }

        /// <summary>
        /// 組合產品Detail實體
        /// </summary>
        public CompositeProductDetail? CompositeProductDetail { get; set; }

        /// <summary>
        /// 組合產品的產品項目清單
        /// </summary>
        public ICollection<CompositeProductItem>? CompositeProductItems { get; set; }

        /// <summary>
        /// 訂單 (針對組合產品detail)的實體清單
        /// </summary>
        public ICollection<OrderForCompositeDetail>? OrderForCompositeDetails { get; set; }

        /// <summary>
        /// 訂單 (針對組合產品item)實體清單
        /// </summary>
        public ICollection<OrderForCompositeItem>? OrderForCompositeItems { get; set; }

        /// <summary>
        /// 訂單 (針對非組合產品)的實體清單
        /// </summary>
        public ICollection<OrderForProduct>? OrderForProducts { get; set; }
    }
}
