using EShopAPI.Cores.Auth.DTOs;
using EShopAPI.Cores.Auth.Services;
using EShopAPI.Cores.ShopUsers;
using EShopCores.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EShopAPI.Cores.Auth
{
    /// <summary>
    /// 驗證 API
    /// </summary>
    [Route("eshop/api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="authenticationService"></param>
        public AuthenticationController(IAuthenticationService authenticationService) 
        {
            _authenticationService = authenticationService;
        }

        /// <summary>
        /// 登入
        /// </summary>
        /// <param name="loginDTO"></param>
        /// <returns></returns>
        /// <response code="200">新增成功</response>
        /// <response code="500">新增失敗</response>
        [HttpPost("Login")]
        [ProducesResponseType(typeof(GenericResponse<ShopUser>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Login(LoginDTO loginDTO) 
        {
            return Ok(GenericResponse<LoginResponseDTO>.GetSuccess(
                await _authenticationService.LoginAsync(loginDTO)));
        }
    }
}
