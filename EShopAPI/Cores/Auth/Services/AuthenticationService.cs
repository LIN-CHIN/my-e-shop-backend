using EShopAPI.Cores.Auth.DTOs;
using EShopAPI.Cores.Auth.JWTs;
using EShopAPI.Cores.ShopUsers;
using EShopAPI.Cores.ShopUsers.Services;
using EShopCores.Errors;
using EShopCores.Responses;

namespace EShopAPI.Cores.Auth.Services
{
    /// <summary>
    /// 驗證的 Service
    /// </summary>
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IShopUserService _shopUserService;
        private readonly IJWTService _jwtService;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="shopUserService"></param>
        /// <param name="jwtService"></param>
        public AuthenticationService(IShopUserService shopUserService,
           IJWTService jwtService) 
        {
            _shopUserService = shopUserService;
            _jwtService = jwtService;
        }

        ///<inheritdoc/>
        public async Task<LoginResponseDTO> LoginAsync(LoginDTO loginDTO) 
        {
            ShopUser? shopUser = await _shopUserService.GetByNumberAsync(loginDTO.UserNumber);
            if(shopUser == null) 
            {
                throw new EShopException(ResponseCodeType.AccountAndPwdError, "帳號不存在");
            }

            if (shopUser.Pwd != loginDTO.Pwd) 
            {
                throw new EShopException(ResponseCodeType.AccountAndPwdError, "密碼不存在");
            }

            string accessToken = await _jwtService.GenerateAccessTokenAsync(shopUser);
            string refreshToken = _jwtService.GenerateRefreshToken(shopUser);

            return new LoginResponseDTO
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken
            };
        }
    }
}
