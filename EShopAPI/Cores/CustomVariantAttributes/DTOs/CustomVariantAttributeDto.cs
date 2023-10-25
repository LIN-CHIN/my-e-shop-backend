using EShopCores.Enums;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;

namespace EShopAPI.Cores.CustomVariantAttributes.DTOs
{
    /// <summary>
    /// 自訂變種屬性查詢結果DTO
    /// </summary>
    public class CustomVariantAttributeDto : EShopObjectDto
    {
        /// <summary>
        /// 屬性代碼
        /// </summary>
        public string Number { get; set; } = null!;

        /// <summary>
        /// 屬性名稱
        /// </summary>
        public string Name { get; set; } = null!;

        /// <summary>
        /// 屬性類型
        /// </summary>
        public CustomVariantAttributeType AttributeType { get; set; }

        /// <summary>
        /// 是否為系統預設
        /// </summary>
        public bool IsSystemDefault { get; set; }

        /// <summary>
        /// 是否啟用
        /// </summary>
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
        public JsonDocument Options { get; set; } = null!;

        /// <summary>
        /// 解析成 CustomVariantAttributeDto
        /// </summary>
        /// <param name="entity">自訂便主屬性的實體</param>
        /// <returns></returns>
        public static CustomVariantAttributeDto? Parse(CustomVariantAttribute? entity) 
        {
            if (entity == null) 
            {
                return null;
            }

            CustomVariantAttributeDto customVariantAttributeDto = new()
            {
                Number = entity.Number,
                Name = entity.Name,
                AttributeType = entity.AttributeType,
                IsSystemDefault = entity.IsSystemDefault,
                IsEnable = entity.IsEnable,
                Options = entity.Options
            };

            customVariantAttributeDto.ParseBaseObject(entity);

            return customVariantAttributeDto;
        }
    }
}
