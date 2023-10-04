using EShopAPI.Cores.Auth.DTOs;

namespace EShopAPI.Cores.Auth.Services
{
    /// <summary>
    /// 驗證的 Service Interface
    /// </summary>
    public interface IAuthenticationService
    {
        /// <summary>
        /// 登入
        /// </summary>
        /// <param name="loginDto">登入資訊</param>
        /// <returns></returns>
        Task<LoginResponseDto> LoginAsync(LoginDto loginDto);
    }
}
