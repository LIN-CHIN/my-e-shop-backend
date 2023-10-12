using EShopAPI.Validations;
using EShopCores.Extensions;
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
        /// 編輯者
        /// </summary>
        [JsonRequired]
        public string UpdateUser { get; set; } = null!;

        /// <summary>
        /// 建立時間
        /// </summary>
        [JsonIgnore]
        public long UpdateDate { get; set; } = DateTime.UtcNow.GetUnixTimeMillisecond();

        /// <summary>
        /// 備註
        /// </summary>
        public string? Remarks { get; set; }

        /// <summary>
        /// 多國語系
        /// </summary>
        public Dictionary<string, string>? Language { get; set; }

        /// <summary>
        /// 設定實體
        /// </summary>
        /// <returns></returns>
        public ShopUser SetEntity(ShopUser shopUser) 
        {
            shopUser.Name = Name;
            shopUser.Pwd = Pwd;
            shopUser.Address = Address;
            shopUser.Email = Email;
            shopUser.Phone = Phone;
            shopUser.UpdateUser = UpdateUser;
            shopUser.UpdateDate = UpdateDate;
            shopUser.Remarks = Remarks;
            shopUser.Language = JsonSerializer.SerializeToDocument(Language);
            return shopUser;
        }
    }
}
