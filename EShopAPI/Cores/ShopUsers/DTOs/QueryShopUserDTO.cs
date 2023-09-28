using System.ComponentModel.DataAnnotations;

namespace EShopAPI.Cores.ShopUsers.DTOs
{
    /// <summary>
    /// 查詢使用者用的DTO
    /// </summary>
    public class QueryShopUserDTO
    {
        /// <summary>
        /// 使用者代碼/帳號
        /// </summary>
        public string? Number { get; set; } 

        /// <summary>
        /// 使用者名稱
        /// </summary>
        public string? Name { get; set; } 

        /// <summary>
        /// Email
        /// </summary>
        public string? Email { get; set; }
    }
}
