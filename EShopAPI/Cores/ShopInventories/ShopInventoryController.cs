using EShopAPI.Cores.ShopInventories.DTOs;
using EShopAPI.Cores.ShopInventories.Services;
using EShopAPI.Filters.RequiredAdminFilters;
using EShopCores.Models;
using EShopCores.Responses;
using Microsoft.AspNetCore.Mvc;

namespace EShopAPI.Cores.ShopInventories
{
    /// <summary>
    /// 商店庫存API
    /// </summary>
    [Route("eshop/api/[controller]")]
    [ApiController]
    public class ShopInventoryController : ControllerBase
    {
        private readonly IShopInventoryService _shopInventoryService;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="shopInventoryService"></param>
        public ShopInventoryController(IShopInventoryService shopInventoryService)
        {
            _shopInventoryService = shopInventoryService;
        }

        /// <summary>
        /// 取得商店庫存清單
        /// </summary>
        /// <param name="pageDto">分頁dto</param>
        /// <param name="queryDto">搜尋條件</param>
        /// <response code="200">查詢成功</response>
        /// <response code="400">輸入的參數有誤</response>
        /// <response code="401">身分驗證失敗</response>
        /// <response code="403">權限不足</response>
        /// <response code="500">查詢失敗</response>
        /// <returns></returns>
        [HttpGet()]
        [RequiredAdmin]
        [ProducesResponseType(typeof(PaginationResponse<ShopInventoryDto?>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status500InternalServerError)]
        public IActionResult Get([FromQuery] QueryPaginationDto pageDto, 
            [FromQuery] QueryShopInventoryDto queryDto) 
        {
            return Ok(PaginationResponse<ShopInventoryDto?>.GetSuccess(
                pageDto.Page,
                pageDto.PageCount,
                _shopInventoryService
                    .Get(queryDto)
                    .Select(si => ShopInventoryDto.Parse(si)))
            );
        }

        /// <summary>
        /// 根據id取得商店庫存
        /// </summary>
        /// <param name="id">要查詢的商店庫存實體id</param>
        /// <response code="200">查詢成功</response>
        /// <response code="400">輸入的參數有誤</response>
        /// <response code="401">身分驗證失敗</response>
        /// <response code="403">權限不足</response>
        /// <response code="500">查詢失敗</response>
        /// <returns></returns>
        [HttpGet("{id}")]
        [RequiredAdmin]
        [ProducesResponseType(typeof(GenericResponse<ShopInventoryDto?>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetByIdAsync([FromRoute] long id) 
        {
            return Ok(GenericResponse<ShopInventoryDto?>
                .GetSuccess(ShopInventoryDto
                    .Parse( await _shopInventoryService
                        .GetByIdAsync(id)))
            );
        }

        /// <summary>
        /// 新增商店庫存
        /// </summary>
        /// <param name="insertDto">要新增的商店庫存資料</param>
        /// <response code="200">新增成功</response>
        /// <response code="400">輸入的參數有誤</response>
        /// <response code="401">身分驗證失敗</response>
        /// <response code="403">權限不足</response>
        /// <response code="500">新增失敗</response>
        /// <returns></returns>
        [HttpPost]
        [RequiredAdmin]
        [ProducesResponseType(typeof(GenericResponse<ShopInventoryDto?>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> InsertAsync([FromBody] InsertShopInventoryDto insertDto) 
        {
            return Ok(GenericResponse<ShopInventoryDto?>
                .GetSuccess(ShopInventoryDto
                    .Parse( await _shopInventoryService
                        .InsertAsync(insertDto)))
            );
        }

        /// <summary>
        /// 編輯商店庫存
        /// </summary>
        /// <param name="updateDto">要編輯的商店庫存資料</param>
        /// <response code="200">編輯成功</response>
        /// <response code="400">輸入的參數有誤</response>
        /// <response code="401">身分驗證失敗</response>
        /// <response code="403">權限不足</response>
        /// <response code="500">編輯失敗</response>
        /// <returns></returns>
        [HttpPut]
        [RequiredAdmin]
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateAsync([FromBody] UpdateShopInventoryDto updateDto)
        {
            await _shopInventoryService
                        .UpdateAsync(updateDto);
            return Ok(GenericResponse<string>.GetSuccess());
        }

        /// <summary>
        /// 啟用商店庫存
        /// </summary>
        /// <param name="id">要啟用的商店庫存id</param>
        /// <response code="200">啟用成功</response>
        /// <response code="400">輸入的參數有誤</response>
        /// <response code="401">身分驗證失敗</response>
        /// <response code="403">權限不足</response>
        /// <response code="500">啟用失敗</response>
        /// <returns></returns>
        [HttpPatch("Enable/{id}")]
        [RequiredAdmin]
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> EnableAsync(long id)
        {
            await _shopInventoryService
                        .EnableAsync(id, true);
            return Ok(GenericResponse<string>.GetSuccess());
        }

        /// <summary>
        /// 停用商店庫存
        /// </summary>
        /// <param name="id">要停用的商店庫存id</param>
        /// <response code="200">停用成功</response>
        /// <response code="400">輸入的參數有誤</response>
        /// <response code="401">身分驗證失敗</response>
        /// <response code="403">權限不足</response>
        /// <response code="500">停用失敗</response>
        /// <returns></returns>
        [HttpPatch("Disable/{id}")]
        [RequiredAdmin]
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DisableAsync(long id)
        {
            await _shopInventoryService
                        .EnableAsync(id, false);
            return Ok(GenericResponse<string>.GetSuccess());
        }
    }
}
