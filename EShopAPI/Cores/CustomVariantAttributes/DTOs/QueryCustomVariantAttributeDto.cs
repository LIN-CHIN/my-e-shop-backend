using EShopCores.Enums;

namespace EShopAPI.Cores.CustomVariantAttributes.DTOs
{
    /// <summary>
    /// 查詢自訂變種屬性用的DTO
    /// </summary>
    public class QueryCustomVariantAttributeDto
    {
        /// <summary>
        /// 屬性代碼
        /// </summary>
        public string? Number { get; set; }

        /// <summary>
        /// 屬性名稱
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// 屬性類型
        /// </summary>
        public CustomVariantAttributeType? AttributeType { get; set; }

        /// <summary>
        /// 是否為系統預設
        /// </summary>
        public bool? IsSystemDefault { get; set; }

        /// <summary>
        /// 是否啟用
        /// </summary>
        public bool? IsEnable { get; set; }

    }
}
