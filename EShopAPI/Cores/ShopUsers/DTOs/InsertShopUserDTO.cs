using EShopCores.Extensions;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace EShopAPI.Cores.ShopUsers.DTOs
{
    /// <summary>
    /// 新增使用者用的DTO
    /// </summary>
    public class InsertShopUserDTO
    {
        /// <summary>
        /// 使用者代碼/帳號
        /// </summary>
        [JsonRequired]
        [StringLength(50)]
        public string Number { get; set; } = null!;

        /// <summary>
        /// 使用者名稱
        /// </summary>
        [JsonRequired]
        [StringLength(50)]
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
        public string? Email { get; set; }

        /// <summary>
        /// 手機
        /// </summary>
        [StringLength(20)]
        public string? Phone { get; set; }

        /// <summary>
        /// 建立者
        /// </summary>
        [JsonRequired]
        public string CreateUser { get; set; } = null!;

        /// <summary>
        /// 建立時間
        /// </summary>
        [JsonIgnore]
        public long CreateDate { get; set; } = DateTime.UtcNow.GetUnixTimeMillisecond();

        /// <summary>
        /// 備註
        /// </summary>
        public string? Remarks { get; set; }

        /// <summary>
        /// 多國語系
        /// </summary>
        public Dictionary<string, string>? Language { get; set; }

        /// <summary>
        /// 轉成實體
        /// </summary>
        /// <returns></returns>
        public ShopUser ToEntity()
        {
            return new ShopUser
            {
                Number = Number,
                Name = Name,
                Pwd = Pwd,
                Address = Address,
                Email = Email,
                Phone = Phone,
                CreateUser = CreateUser,
                CreateDate = CreateDate,
                Remarks = Remarks,
                Language = System.Text.Json.JsonSerializer.SerializeToDocument(Language)
            };
        }
    }
}
