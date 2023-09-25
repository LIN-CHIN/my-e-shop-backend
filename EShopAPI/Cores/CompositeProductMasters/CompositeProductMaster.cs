using EShopAPI.Cores.CompositeProductDetails;
using EShopAPI.Cores.MapCompositeProductDeliveries;
using EShopCores.Enums;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;

namespace EShopAPI.Cores.CompositeProductMasters
{
    /// <summary>
    /// 組合產品主檔
    /// </summary>
    [Table("composite_product_master", Schema = "eshop")]
    [Comment("組合產品主檔")]
    public class CompositeProductMaster : EShopObject
    {
        /// <summary>
        /// 組合產品代碼
        /// </summary>
        [Required]
        [Column("number", TypeName = "varchar(25)")]
        [Comment("組合產品代碼")]
        [StringLength(25)]
        public string Number { get; set; } = null!;

        /// <summary>
        /// 組合產品名稱
        /// </summary>
        [Required]
        [Column("name", TypeName = "varchar(50)")]
        [Comment("組合產品名稱")]
        [StringLength(50)]
        public string Name { get; set; } = null!;

        /// <summary>
        /// 組合產品類型
        /// </summary>
        [Required]
        [Column("composite_product_type")]
        [Comment("組合產品類型")]
        public ProductType CompositeProductType { get; set; }

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
        /// 這個產品變種屬性有哪一些值?
        /// ex: color:[red, blue], size[S,M]
        /// </remarks>
        [Column("variant_attribute", TypeName = "jsonb")]
        [Comment("變種屬性, 這些變種屬性有哪些值? ex: color:[red, blue], size[S,M]")]
        public JsonDocument? VariantAttribute { get; set; }

        /// <summary>
        /// 組合產品細項清單
        /// </summary>
        public ICollection<CompositeProductDetail>? CompositeProductDetails { get; set; }

        /// <summary>
        /// 組合產品與物流種類關聯的實體清單
        /// </summary>
        public ICollection<MapCompositeProductDelivery>? MapCompositeProductDeliveries { get; set; }
    }
}
