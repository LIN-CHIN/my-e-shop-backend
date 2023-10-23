using EShopAPI.Validations;
using EShopCores.Extensions;
using EShopCores.Json;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace EShopAPI.Cores.ShopUsers.DTOs
{
    /// <summary>
    /// 更新使用者用的DTO
    /// </summary>
    public class UpdateShopUserDto
    {
        /// <summary>
        /// 使用者id
        /// </summary>
        [JsonRequired]
        public long Id { get; set; }

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
        /// 備註
        /// </summary>
        public string? Remarks { get; set; }

        /// <summary>
        /// 多國語系
        /// </summary>
        public IEnumerable<LanguageJson>? Languages { get; set; }

        /// <summary>
        /// 設定實體
        /// </summary>
        /// <param name="shopUser"></param>
        /// <param name="updateUser">編輯者帳號</param>
        /// <returns></returns>
        public ShopUser SetEntity(ShopUser shopUser, string updateUser) 
        {
            shopUser.Name = Name;
            shopUser.Pwd = Pwd;
            shopUser.Address = Address;
            shopUser.Email = Email;
            shopUser.Phone = Phone;
            shopUser.Remarks = Remarks;
            shopUser.Language = JsonSerializer.SerializeToDocument(Languages);
            shopUser.UpdateUser = updateUser;
            shopUser.UpdateDate = DateTime.UtcNow.GetUnixTimeMillisecond();
            return shopUser;
        }
    }
}
