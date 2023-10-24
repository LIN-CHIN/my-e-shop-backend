using EShopCores.Enums;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;

namespace EShopAPI.Cores.CustomVariantAttributes
{
    /// <summary>
    /// 自訂變種屬性
    /// </summary>
    [Table("custom_variant_attribute", Schema = "eshop")]
    [Comment("自訂變種屬性")]
    public class CustomVariantAttribute : EShopObject
    {
        /// <summary>
        /// 屬性代碼
        /// </summary>
        [Required]
        [Column("number", TypeName = "varchar(50)")]
        [Comment("屬性代碼")]
        [StringLength(50)]
        public string Number { get; set; } = null!;

        /// <summary>
        /// 屬性名稱
        /// </summary>
        [Required]
        [Column("name", TypeName = "varchar(50)")]
        [Comment("屬性名稱")]
        [StringLength(50)]
        public string Name { get; set; } = null!;

        /// <summary>
        /// 屬性類型
        /// </summary>
        [Required]
        [Column("attribute_type")]
        [Comment("屬性類型")]
        public CustomVariantAttributeType AttributeType { get; set; }

        /// <summary>
        /// 是否為系統預設
        /// </summary>
        [Required]
        [Column("is_system_default")]
        [Comment("是否為系統預設")]
        public bool IsSystemDefault { get; set; }

        /// <summary>
        /// 是否啟用
        /// </summary>
        [Required]
        [Column("is_enable")]
        [Comment("是否啟用")]
        public bool IsEnable { get; set; }

        /// <summary>
        /// 屬性的選項清單
        /// </summary>
        /// <remarks>
        /// [
        ///  {
        ///      "id": "GUID()",
        ///      "name": "紅色",
        ///      "hex": "#FFFFFF"
        ///  }
        /// ]
        /// </remarks>
        [Required]
        [Column("options", TypeName = "jsonb")]
        [Comment("屬性的選項清單")]
        public JsonDocument Options { get; set; } = null!;
    }
}
