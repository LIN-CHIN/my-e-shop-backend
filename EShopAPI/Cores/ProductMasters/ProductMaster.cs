using EShopAPI.Cores.MapProductCategories;
using EShopAPI.Cores.MapProductDeliveryCategorys;
using EShopAPI.Cores.ProductDetails;
using EShopCores.Enums;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;

namespace EShopAPI.Cores.ProductMasters
{
    /// <summary>
    /// 產品主檔
    /// </summary>
    /// <remarks>
    /// 主要用來控制產品主要資料、屬性
    /// </remarks>
    [Table("product_master", Schema = "eshop")]
    [Comment("產品主檔")]
    public class ProductMaster : EShopObject
    {
        /// <summary>
        /// 產品主編號
        /// </summary>
        [Required]
        [Column("number", TypeName = "varchar(25)")]
        [Comment("產品主編號")]
        [StringLength(25)]
        public string Number { get; set; } = null!;

        /// <summary>
        /// 產品主名稱
        /// </summary>
        [Required]
        [Column("name", TypeName = "varchar(50)")]
        [Comment("產品主名稱")]
        [StringLength(50)]
        public string Name { get; set; } = null!;

        /// <summary>
        /// 產品類型
        /// </summary>
        [Required]
        [Column("product_type")]
        [Comment("產品類型")]
        public ProductType ProductType { get; set; }

        /// <summary>
        /// 是否啟用
        /// </summary>
        [Required]
        [Column("is_enable")]
        [Comment("是否啟用")]
        public bool IsEnable{ get; set; }

        /// <summary>
        /// 變種屬性
        /// </summary>
        /// <remarks>
        /// 這個產品變種屬性有哪一些值?
        /// ex: color:[red, blue], size[S,M]
        /// </remarks>
        [Column("variant_attribute", TypeName = "jsonb")]
        [Comment("變種屬性, 這些變種屬性有哪些值? ex: color:[red, blue], size[S,M]")]
        public JsonDocument? VariantAttribute { get; set; }

        /// <summary>
        /// 產品子項目清單
        /// </summary>
        public ICollection<ProductDetail>? ProductDetails { get; set; }

        /// <summary>
        /// 產品主表與物流種類關聯的實體清單
        /// </summary>
        public ICollection<MapProductDeliveryCategory>? MapProductDeliveryCategories { get; set; }

        /// <summary>
        /// 產品主表與產品類別關聯的實體清單
        /// </summary>
        public ICollection<MapProductCategory>? MapProductCategories { get; set; }
    }
}
