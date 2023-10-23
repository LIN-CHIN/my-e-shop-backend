using EShopAPI.Validations;
using EShopCores.Extensions;
using EShopCores.Json;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace EShopAPI.Cores.ShopUsers.DTOs
{
    /// <summary>
    /// 新增使用者用的DTO
    /// </summary>
    public class InsertShopUserDto
    {
        /// <summary>
        /// 使用者代碼/帳號
        /// </summary>
        [JsonRequired]
        [StringLength(50)]
        [NumberValidation]
        public string Number { get; set; } = null!;

        /// <summary>
        /// 使用者名稱
        /// </summary>
        [JsonRequired]
        [StringLength(50)]
        [NameValidation]  
        public string Name { get; set; } = null!;

        /// <summary>
        /// 密碼
        /// </summary>
        [JsonRequired]
        public string Pwd { get; set; } = null!;

        /// <summary>
        /// 地址
        /// </summary>
        [StringLength(100)]
        public string? Address { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        [StringLength(50)]
        [EmailValidation]
        public string? Email { get; set; }

        /// <summary>
        /// 手機
        /// </summary>
        [StringLength(20)]
        public string? Phone { get; set; }

        /// <summary>
        /// 是否啟用
        /// </summary>
        [JsonRequired]
        public bool IsEnable { get; set; } = true;

        /// <summary>
        /// 是否為管理員
        /// </summary>
        [JsonRequired]
        public bool IsAdmin { get; set; } = false;

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
        /// <param name="createUser">建立者</param>
        /// <returns></returns>
        public ShopUser ToEntity(string createUser)
        {
            return new ShopUser
            {
                Number = Number,
                Name = Name,
                Pwd = Pwd,
                Address = Address,
                Email = Email,
                Phone = Phone,
                IsEnable = IsEnable,
                IsAdmin = IsAdmin,
                CreateUser = createUser,
                CreateDate = DateTime.UtcNow.GetUnixTimeMillisecond(),
                Remarks = Remarks,
                Language = JsonSerializer.SerializeToDocument(Languages)
            };
        }
    }
}
