using EShopAPI.Cores.CompositeProductItems;
using EShopAPI.Cores.CompositeProductMasters;
using EShopAPI.Cores.EShopUnits;
using EShopAPI.Cores.ProductDetails;
using EShopAPI.Cores.ShopInventories;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EShopAPI.Cores.CompositeProductDetails
{
    /// <summary>
    /// 組合產品子檔
    /// </summary>
    [Table("composite_product_detail", Schema = "eshop")]
    [Comment("組合產品子檔")]
    public class CompositeProductDetail : EShopObject
    {
        /// <summary>
        /// 組合產品主檔id
        /// </summary>
        [Required]
        [Column("master_id")]
        [Comment("組合產品主檔id")]
        [ForeignKey("CompositeProductMaster")]
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
        /// 商店單位id
        /// </summary>
        [Required]
        [Column("eshop_unit_id")]
        [Comment("商店單位id")]
        [ForeignKey("EShopUnit")]
        public long EShopUnitId { get; set; }

        /// <summary>
        /// 單件價格(原價)
        /// </summary>
        [Required]
        [Column("price")]
        [Comment("單件價格(原價)")]
        public int Price { get; set; }

        /// <summary>
        /// 折扣數
        /// </summary>
        [Required]
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
        /// 組合產品主檔
        /// </summary>
        public CompositeProductMaster? CompositeProductMaster { get; set; }

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
    }
}
