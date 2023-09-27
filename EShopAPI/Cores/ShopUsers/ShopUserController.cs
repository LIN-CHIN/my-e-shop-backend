using EShopAPI.Cores.ShopUsers.DTOs;
using EShopAPI.Cores.ShopUsers.Services;
using EShopCores.Responses;
using Microsoft.AspNetCore.Mvc;

namespace EShopAPI.Cores.ShopUsers
{
    /// <summary>
    /// 使用者API
    /// </summary>
    [Route("eshop/api/[controller]")]
    [ApiController]
    public class ShopUserController : ControllerBase
    {
        private readonly IShopUserService _shopUserService;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="shopUserService"></param>
        public ShopUserController(IShopUserService shopUserService) 
        {
            _shopUserService = shopUserService;
        }

        /// <summary>
        /// 新增使用者
        /// </summary>
        /// <param name="insertDTO">要新增的使用者資訊</param>
        /// <returns></returns>
        /// <response code="200">新增成功</response>
        /// <response code="500">新增失敗</response>
        [HttpPost]
        [ProducesResponseType(typeof(GenericResponse<ShopUser>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Insert([FromBody] InsertShopUserDTO insertDTO) 
        {
            return Ok(GenericResponse<ShopUser>.GetSuccess(
                await _shopUserService.InsertAsync(insertDTO)));
        }
    }
}
