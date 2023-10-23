using EShopAPI.Validations;
using EShopCores.Extensions;
using EShopCores.Json;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace EShopAPI.Cores.ShopRoles.DTOs
{
    /// <summary>
    /// 新增角色用的DTO
    /// </summary>
    public class InsertShopRoleDto
    {
        /// <summary>
        /// 角色代碼
        /// </summary>
        [JsonRequired]
        [StringLength(50)]
        [NumberValidation]
        public string Number { get; set; } = null!;

        /// <summary>
        /// 角色名稱
        /// </summary>
        [JsonRequired]
        [StringLength(50)]
        [NameValidation]
        public string Name { get; set; } = null!;

        /// <summary>
        /// 是否啟用
        /// </summary>
        /// <remarks>
        /// 預設 = true
        /// </remarks>
        [JsonRequired]
        public bool IsEnable { get; set; } = true;

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
        public ShopRole ToEntity(string userNumber)
        {
            return new ShopRole
            {
                Number = Number,
                Name = Name,
                IsEnable = IsEnable,
                CreateUser = userNumber,
                CreateDate = DateTime.UtcNow.GetUnixTimeMillisecond(),
                Remarks = Remarks,
                Language = JsonSerializer.SerializeToDocument(Languages)
            };
        }
    }
}
