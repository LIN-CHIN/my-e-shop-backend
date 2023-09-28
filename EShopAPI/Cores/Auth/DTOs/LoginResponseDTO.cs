namespace EShopAPI.Cores.Auth.DTOs
{
    /// <summary>
    /// 登入回傳結果用的DTO
    /// </summary>
    public class LoginResponseDto
    {
        /// <summary>
        /// Token
        /// </summary>
        public string AccessToken { get; set; } = null!;

        /// <summary>
        /// Refresh Token
        /// </summary>
        public string RefreshToken { get; set; } = null!;
    }
}
