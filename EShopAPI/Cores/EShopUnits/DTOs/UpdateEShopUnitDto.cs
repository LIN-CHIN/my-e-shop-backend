using EShopAPI.Validations;
using EShopCores.Extensions;
using EShopCores.Json;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace EShopAPI.Cores.EShopUnits.DTOs
{
    /// <summary>
    /// 編輯商店單位用的DTO
    /// </summary>
    public class UpdateEShopUnitDto
    {
        /// <summary>
        /// 要被編輯的id
        /// </summary>
        [JsonRequired]
        public long Id { get; set; }

        /// <summary>
        /// 單位名稱
        /// </summary>
        [JsonRequired]
        [StringLength(20)]
        [NameValidation]
        public string Name { get; set; } = null!;

        /// <summary>
        /// 備註
        /// </summary>
        public string? Remarks { get; set; }

        /// <summary>
        /// 多國語系
        /// </summary>
        public IEnumerable<LanguageJson>? Languages { get; set; }

        /// <summary>
        /// 設定要被修改的實體
        /// </summary>
        /// <param name="eShopUnit">要被修改的實體</param>
        /// <param name="userNumber">修改者帳號</param>
        /// <returns></returns>
        public EShopUnit SetEntity(EShopUnit eShopUnit, string userNumber) 
        {
            eShopUnit.Name = Name;
            eShopUnit.Remarks = Remarks;
            eShopUnit.Language = JsonSerializer.SerializeToDocument(Languages);
            eShopUnit.UpdateUser = userNumber;
            eShopUnit.UpdateDate = DateTime.UtcNow.GetUnixTimeMillisecond();

            return eShopUnit;
        }
    }
}
