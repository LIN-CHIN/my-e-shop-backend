using EShopAPI.Cores.CompositeProducts.DTOs;
using EShopAPI.Cores.CompositeProducts;
using EShopAPI.Filters.RequiredAdminFilters;
using EShopCores.Models;
using EShopCores.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EShopAPI.Cores.CompositeProductItems.Services;
using EShopAPI.Cores.CompositeProductItems.DTOs;

namespace EShopAPI.Cores.CompositeProductItems
{
    /// <summary>
    /// 組合產品項目API
    /// </summary>
    [Route("eshop/api/[controller]")]
    [ApiController]
    public class CompositeProductItemController : ControllerBase
    {
        private readonly ICompositeProductItemService _compositeProductItemService;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="compositeProductItemService"></param>
        public CompositeProductItemController(ICompositeProductItemService compositeProductItemService) 
        {
            _compositeProductItemService = compositeProductItemService;
        }

        /// <summary>
        /// 根據組合產品id查詢所有組合產品項目
        /// </summary>
        /// <param name="pageDto">分頁資訊</param>
        /// <param name="compositeProductId">組合產品的id</param>
        /// <returns></returns>
        /// <response code="200">查詢成功</response>
        /// <response code="400">輸入的參數有誤</response>
        /// <response code="401">身分驗證失敗</response>
        /// <response code="403">權限不足</response>
        /// <response code="500">查詢失敗</response>
        [HttpGet("CompositeProduct/{compositeProductId}")]
        [RequiredAdmin]
        [ProducesResponseType(typeof(PaginationResponse<CompositeProductItemDto?>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status500InternalServerError)]
        public IActionResult GetByCompositeProductId(
            [FromQuery] QueryPaginationDto pageDto,
            [FromRoute] long compositeProductId)
        {
            return Ok(PaginationResponse<CompositeProductItemDto?>.GetSuccess(
                pageDto.Page,
                pageDto.PageCount,
                _compositeProductItemService.GetByCompositeProductId(compositeProductId)
                    .Select(p => CompositeProductItemDto.Parse(p)
            )));
        }

        /// <summary>
        /// 根據id查詢組合產品項目
        /// </summary>
        /// <param name="id">組合產品項目的id</param>
        /// <returns></returns>
        /// <response code="200">查詢成功</response>
        /// <response code="400">輸入的參數有誤</response>
        /// <response code="401">身分驗證失敗</response>
        /// <response code="403">權限不足</response>
        /// <response code="500">查詢失敗</response>
        [HttpGet("{id}")]
        [RequiredAdmin]
        [ProducesResponseType(typeof(GenericResponse<CompositeProductItemDto?>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetByIdAsync(long id)
        {
            CompositeProductItem? compositeProductItem = 
                await _compositeProductItemService.GetByIdAsync(id);

            return Ok(GenericResponse<CompositeProductItemDto?>
                .GetSuccess(CompositeProductItemDto.Parse(compositeProductItem)));
        }

        /// <summary>
        /// 新增組合產品項目
        /// </summary>
        /// <param name="insertDto">要新增的組合產品項目資訊</param>
        /// <returns></returns>
        /// <response code="200">新增成功</response>
        /// <response code="400">輸入的參數有誤</response>
        /// <response code="401">身分驗證失敗</response>
        /// <response code="403">權限不足</response>
        /// <response code="500">新增失敗</response>
        [HttpPost]
        [RequiredAdmin]
        [ProducesResponseType(typeof(GenericResponse<CompositeProductItemDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> InsertAsync([FromBody] InsertCompositeProductItemDto insertDto)
        {
            return Ok(GenericResponse<CompositeProductItemDto>
                    .GetSuccess(CompositeProductItemDto
                        .Parse(await _compositeProductItemService.InsertAsync(insertDto))
                    )
            );
        }

        /// <summary>
        /// 編輯組合產品項目
        /// </summary>
        /// <param name="updateDto">要編輯的組合項目產品資訊</param>
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
        public async Task<IActionResult> UpdateAsync([FromBody] UpdateCompositeProductItemDto updateDto)
        {
            await _compositeProductItemService.UpdateAsync(updateDto);
            return Ok(GenericResponse<string>.GetSuccess());
        }

        /// <summary>
        /// 刪除組合產品項目
        /// </summary>
        /// <param name="id">要刪除的組合產品項目id</param>
        /// <returns></returns>
        /// <response code="200">編輯成功</response>
        /// <response code="400">輸入的參數有誤</response>
        /// <response code="401">身分驗證失敗</response>
        /// <response code="403">權限不足</response>
        /// <response code="500">新增失敗</response>
        [HttpDelete("{id}")]
        [RequiredAdmin]
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteAsync(long id)
        {
            await _compositeProductItemService.DeleteAsync(id);
            return Ok(GenericResponse<string>.GetSuccess());
        }
    }
}
