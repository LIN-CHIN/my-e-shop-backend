using EShopAPI.Cores.ShopUsers.DTOs;
using EShopAPI.Cores.ShopUsers.Services;
using EShopCores.Models;
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
        /// 查詢所有使用者
        /// </summary>
        /// <param name="pageDTO">分頁資訊</param>
        /// <param name="queryDTO">要新增的使用者資訊</param>
        /// <returns></returns>
        /// <response code="200">查詢成功</response>
        /// <response code="500">查詢失敗</response>
        [HttpGet]
        [ProducesResponseType(typeof(PaginationResponse<ShopUserDTO?>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status500InternalServerError)]
        public IActionResult Get(
            [FromQuery] QueryPaginationDTO pageDTO, 
            [FromQuery] QueryShopUserDTO queryDTO)
        {
            return Ok(PaginationResponse<ShopUserDTO?>.GetSuccess(
                pageDTO.Page,
                pageDTO.PageCount,
                _shopUserService.Get(queryDTO).Select(user => ShopUserDTO.Parse(user)
            )));
        }

        /// <summary>
        /// 根據id查詢使用者
        /// </summary>
        /// <param name="id">使用者的id</param>
        /// <returns></returns>
        /// <response code="200">查詢成功</response>
        /// <response code="500">查詢失敗</response>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(GenericResponse<ShopUserDTO?>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetByIdAsync(long id)
        {
            ShopUser? shopUser = await _shopUserService.GetByIdAsync(id);
            return Ok(GenericResponse<ShopUserDTO?>.GetSuccess(ShopUserDTO.Parse(shopUser)));
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

        /// <summary>
        /// 編輯使用者
        /// </summary>
        /// <param name="updateDTO">要編輯的使用者資訊</param>
        /// <returns></returns>
        /// <response code="200">編輯成功</response>
        /// <response code="500">編輯失敗</response>
        [HttpPut]
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Update([FromBody] UpdateShopUserDTO updateDTO)
        {
            await _shopUserService.UpdaeAsync(updateDTO);
            return Ok(GenericResponse<string>.GetSuccess());
        }

        /// <summary>
        /// 啟用使用者
        /// </summary>
        /// <param name="id">要設定啟用的 使用者id</param>
        /// <returns></returns>
        /// <response code="200">編輯成功</response>
        /// <response code="500">編輯失敗</response>
        [HttpPatch("Enable/{id}")]
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> SetEnable(long id)
        {
            await _shopUserService.EnableAsync(id, true);
            return Ok(GenericResponse<string>.GetSuccess());
        }

        /// <summary>
        /// 停用使用者
        /// </summary>
        /// <param name="id">要設定啟用的 使用者id</param>
        /// <returns></returns>
        /// <response code="200">編輯成功</response>
        /// <response code="500">編輯失敗</response>
        [HttpPatch("Disable/{id}")]
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> SetDesable(long id)
        {
            await _shopUserService.EnableAsync(id, false);
            return Ok(GenericResponse<string>.GetSuccess());
        }
    }
}
