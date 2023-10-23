using EShopAPI.Cores.CompositeProductItems;
using EShopAPI.Cores.CompositeProducts;
using EShopAPI.Cores.OrderCompositeProducts;
using EShopAPI.Cores.OrderForCompositeItems;
using EShopAPI.Cores.OrderProducts;
using EShopAPI.Cores.Products;
using EShopCores.Enums;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;

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
        /// 產品類型
        /// </summary>
        [Required]
        [Column("product_type")]
        [Comment("產品類型")]
        public ProductType ProductType { get; set; }

        /// <summary>
        /// 是否為組合產品
        /// </summary>
        [Required]
        [Column("is_composite")]
        [Comment("是否為組合產品")]
        public bool IsComposite { get; set; }

        /// <summary>
        /// 是否只能讓組合產品使用
        /// </summary>
        [Required]
        [Column("is_composite_only")]
        [Comment("是否只能讓組合產品使用")]
        public bool IsCompositeOnly { get; set; }

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
        /// 商品細項
        /// </summary>
        public Product? Product { get; set; }

        /// <summary>
        /// 組合產品Detail實體
        /// </summary>
        public CompositeProduct? CompositeProduct { get; set; }

        /// <summary>
        /// 組合產品的產品項目清單
        /// </summary>
        public ICollection<CompositeProductItem>? CompositeProductItems { get; set; }

        /// <summary>
        /// 訂單 (針對組合產品detail)的實體清單
        /// </summary>
        public ICollection<OrderCompositeProduct>? OrderCompositeProducts { get; set; }

        /// <summary>
        /// 訂單 (針對組合產品item)實體清單
        /// </summary>
        public ICollection<OrderCompositeProductItem>? OrderCompositeProductItems { get; set; }

        /// <summary>
        /// 訂單 (針對非組合產品)的實體清單
        /// </summary>
        public ICollection<OrderProduct>? OrderProducts { get; set; }
    }
}
