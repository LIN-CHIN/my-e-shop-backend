using EShopAPI.Validations;
using EShopCores.Enums;
using EShopCores.Extensions;
using EShopCores.Json;
using EShopCores.Json.VariantAttributeOptions;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace EShopAPI.Cores.CustomVariantAttributes.DTOs
{
    /// <summary>
    /// 新增自訂變種屬性用的DTO
    /// </summary>
    public class InsertCustomVariantAttributeDto
    {
        /// <summary>
        /// 屬性代碼
        /// </summary>
        [JsonRequired]
        [StringLength(50)]
        [NumberValidation]
        public string Number { get; set; } = null!;

        /// <summary>
        /// 屬性名稱
        /// </summary>
        [JsonRequired]
        [StringLength(50)]
        [NameValidation]
        public string Name { get; set; } = null!;

        /// <summary>
        /// 屬性類型
        /// </summary>
        [JsonRequired]
        [EnumValidation]
        public CustomVariantAttributeType AttributeType { get; set; }

        /// <summary>
        /// 是否為系統預設
        /// </summary>
        [JsonIgnore]
        public bool IsSystemDefault { get; set; } = false;

        /// <summary>
        /// 是否啟用
        /// </summary>
        [JsonRequired]
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
        [JsonRequired]
        public IEnumerable<VariantAttributeOptionBaseJson> Options { get; set; } = null!;

        /// <summary>
        /// 備註
        /// </summary>
        public string? Remarks { get; set; }

        /// <summary>
        /// 多國語系
        /// </summary>
        public IEnumerable<LanguageJson>? Languages { get; set; }

        /// <summary>
        /// 轉成實體
        /// </summary>
        /// <param name="userNumber">新增者的帳號</param>
        /// <returns></returns>
        public CustomVariantAttribute ToEntity(string userNumber) 
        {
            return new CustomVariantAttribute
            {
                Number = Number,
                Name = Name,
                AttributeType = AttributeType,
                IsSystemDefault = IsSystemDefault,
                IsEnable = IsEnable,
                Options = JsonSerializer.SerializeToDocument(Options),
                Remarks = Remarks,
                Language = JsonSerializer.SerializeToDocument(Languages),
                CreateUser = userNumber,
                CreateDate = DateTime.UtcNow.GetUnixTimeMillisecond()
            };
        }
    }
}
