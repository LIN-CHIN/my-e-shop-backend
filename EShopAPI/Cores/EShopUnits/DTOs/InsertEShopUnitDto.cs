using EShopCores.Json;
using System.ComponentModel.DataAnnotations;
using EShopAPI.Validations;
using System.Text.Json;
using EShopCores.Extensions;
using System.Text.Json.Serialization;

namespace EShopAPI.Cores.EShopUnits.DTOs
{
    /// <summary>
    /// 新增商店單位用的DTO
    /// </summary>
    public class InsertEShopUnitDto
    {
        /// <summary>
        /// 單位代碼
        /// </summary>
        [JsonRequired]
        [StringLength(50)]
        [NumberValidation]
        public string Number { get; set; } = null!;

        /// <summary>
        /// 單位名稱
        /// </summary>
        [JsonRequired]
        [StringLength(20)]
        [NameValidation]
        public string Name { get; set; } = null!;

        /// <summary>
        /// 是否啟用
        /// </summary>
        [JsonRequired]
        public bool IsEnable { get; set; }

        /// <summary>
        /// 是否為系統預設
        /// </summary>
        [JsonIgnore]
        public bool IsSystemDefault { get; set; } = false;

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
        /// <param name="userNumber">新增者帳號</param>
        /// <returns></returns>
        public EShopUnit ToEntity(string userNumber) 
        {
            return new EShopUnit
            {
                Number = Number,
                Name = Name,
                IsEnable = IsEnable,
                IsSystemDefault = IsSystemDefault,
                Remarks = Remarks,
                Language = JsonSerializer.SerializeToDocument(Languages),
                CreateUser = userNumber,
                CreateDate = DateTime.UtcNow.GetUnixTimeMillisecond()
            };
        }
    }
}
