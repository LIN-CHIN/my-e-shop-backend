using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace EShopAPI.Cores.Auth.DTOs
{
    /// <summary>
    /// 登入DTO
    /// </summary>
    public class LoginDto
    {
        /// <summary>
        /// 使用者帳號
        /// </summary>
        [JsonRequired]
        [StringLength(50)]
        public string UserNumber { get; set; } = null!;

        /// <summary>
        /// 使用者密碼
        /// </summary>
        [JsonRequired]
        public string Pwd { get; set; } = null!;

    }
}
