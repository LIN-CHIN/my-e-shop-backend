using EShopAPI.Validations;
using EShopCores.Json;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.Text.Json;
using EShopCores.Extensions;

namespace EShopAPI.Cores.CustomVariantAttributes.DTOs
{
    /// <summary>
    /// 修改自訂變種屬性用的DTO
    /// </summary>
    public class UpdateCustomVariantAttributeDto
    {
        /// <summary>
        /// 要編輯的自訂變種屬性id
        /// </summary>
        [JsonRequired]
        public long Id { get; set; }

        /// <summary>
        /// 屬性名稱
        /// </summary>
        [JsonRequired]
        [StringLength(50)]
        [NameValidation]
        public string Name { get; set; } = null!;

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
        public IEnumerable<VariantAttributeOptionJson> Options { get; set; } = null!;

        /// <summary>
        /// 備註
        /// </summary>
        public string? Remarks { get; set; }

        /// <summary>
        /// 多國語系
        /// </summary>
        public IEnumerable<LanguageJson>? Languages { get; set; }

        /// <summary>
        /// 用DTO設定實體的屬性值
        /// </summary>
        /// <param name="entity">要被編輯的實體</param>
        /// <param name="userNumber">編輯者的帳號</param>
        /// <returns></returns>
        public CustomVariantAttribute SetEntity(CustomVariantAttribute entity,
            string userNumber) 
        {
            entity.Name = Name;
            entity.Options = JsonSerializer.SerializeToDocument(Options);
            entity.Remarks = Remarks;
            entity.Language = JsonSerializer.SerializeToDocument(Languages);
            entity.UpdateUser = userNumber;
            entity.UpdateDate = DateTime.UtcNow.GetUnixTimeMillisecond();
         
            return entity;
        }
    }
}
