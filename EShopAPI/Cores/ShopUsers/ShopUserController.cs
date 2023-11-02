using EShopAPI.Cores.ShopUsers.DTOs;
using EShopAPI.Cores.ShopUsers.Services;
using EShopAPI.Filters;
using EShopAPI.Filters.RequiredAdminFilters;
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
        /// <param name="pageDto">分頁資訊</param>
        /// <param name="queryDto">要查詢的使用者資訊</param>
        /// <returns></returns>
        /// <response code="200">查詢成功</response>
        /// <response code="400">輸入的參數有誤</response>
        /// <response code="401">身分驗證失敗</response>
        /// <response code="403">權限不足</response>
        /// <response code="500">查詢失敗</response>
        [HttpGet]
        [RequiredAdmin]
        [ProducesResponseType(typeof(PaginationResponse<ShopUserDto?>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status500InternalServerError)]
        public IActionResult Get(
            [FromQuery] QueryPaginationDto pageDto, 
            [FromQuery] QueryShopUserDto queryDto)
        {
            return Ok(PaginationResponse<ShopUserDto?>.GetSuccess(
                pageDto.Page,
                pageDto.PageCount,
                _shopUserService.Get(queryDto).Select(user => ShopUserDto.Parse(user)
            )));
        }

        /// <summary>
        /// 根據id查詢使用者
        /// </summary>
        /// <param name="id">使用者的id</param>
        /// <returns></returns>
        /// <response code="200">查詢成功</response>
        /// <response code="400">輸入的參數有誤</response>
        /// <response code="401">身分驗證失敗</response>
        /// <response code="403">權限不足</response>
        /// <response code="500">查詢失敗</response>
        [HttpGet("{id}")]
        [RequiredAdmin]
        [ProducesResponseType(typeof(GenericResponse<ShopUserDto?>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetByIdAsync(long id)
        {
            ShopUser? shopUser = await _shopUserService.GetByIdAsync(id);
            return Ok(GenericResponse<ShopUserDto?>.GetSuccess(ShopUserDto.Parse(shopUser)));
        }

        /// <summary>
        /// 新增使用者
        /// </summary>
        /// <param name="insertDto">要新增的使用者資訊</param>
        /// <returns></returns>
        /// <response code="200">新增成功</response>
        /// <response code="400">輸入的參數有誤</response>
        /// <response code="401">身分驗證失敗</response>
        /// <response code="403">權限不足</response>
        /// <response code="500">新增失敗</response>
        [HttpPost]
        [RequiredAdmin]
        [ProducesResponseType(typeof(GenericResponse<ShopUserDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> InsertAsync([FromBody] InsertShopUserDto insertDto) 
        {
            return Ok(GenericResponse<ShopUserDto>
                    .GetSuccess(ShopUserDto
                        .Parse(await _shopUserService.InsertAsync(insertDto))
                    )
            );
        }

        /// <summary>
        /// 編輯使用者
        /// </summary>
        /// <param name="updateDto">要編輯的使用者資訊</param>
        /// <returns></returns>
        /// <response code="200">編輯成功</response>
        /// <response code="400">輸入的參數有誤</response>
        /// <response code="401">身分驗證失敗</response>
        /// <response code="403">權限不足</response>
        /// <response code="500">新增失敗</response>
        [HttpPut]
        [RequiredAdmin]
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateAsync([FromBody] UpdateShopUserDto updateDto)
        {
            await _shopUserService.UpdateAsync(updateDto);
            return Ok(GenericResponse<string>.GetSuccess());
        }

        /// <summary>
        /// 啟用使用者
        /// </summary>
        /// <param name="id">要設定啟用的 使用者id</param>
        /// <returns></returns>
        /// <response code="200">啟用成功</response>
        /// <response code="400">輸入的參數有誤</response>
        /// <response code="401">身分驗證失敗</response>
        /// <response code="403">權限不足</response>
        /// <response code="500">啟用失敗</response>
        [HttpPatch("Enable/{id}")]
        [RequiredAdmin]
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> SetEnableAsync(long id)
        {
            await _shopUserService.EnableAsync(id, true);
            return Ok(GenericResponse<string>.GetSuccess());
        }

        /// <summary>
        /// 停用使用者
        /// </summary>git
        /// <param name="id">要設定停用的使用者id</param>
        /// <returns></returns>
        /// <response code="200">停用成功</response>
        /// <response code="400">輸入的參數有誤</response>
        /// <response code="401">身分驗證失敗</response>
        /// <response code="403">權限不足</response>
        /// <response code="500">停用失敗</response>
        [HttpPatch("Disable/{id}")]
        [RequiredAdmin]
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> SetDisableAsync(long id)
        {
            await _shopUserService.EnableAsync(id, false);
            return Ok(GenericResponse<string>.GetSuccess());
        }
    }
}
