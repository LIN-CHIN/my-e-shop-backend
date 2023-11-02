using EShopAPI.Cores.CompositeProducts.Services;
using EShopAPI.Cores.Products.DTOs;
using EShopAPI.Cores.Products;
using EShopAPI.Filters.RequiredAdminFilters;
using EShopCores.Models;
using EShopCores.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EShopAPI.Cores.CompositeProducts.DTOs;

namespace EShopAPI.Cores.CompositeProducts
{
    /// <summary>
    /// 組合產品API
    /// </summary>
    [Route("eshop/api/[controller]")]
    [ApiController]
    public class CompositeProductController : ControllerBase
    {
        private readonly ICompositeProductService _compositeProductService;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="compositeProductService"></param>
        public CompositeProductController(ICompositeProductService compositeProductService) 
        {
            _compositeProductService = compositeProductService;
        }

        /// <summary>
        /// 查詢所有組合產品
        /// </summary>
        /// <param name="pageDto">分頁資訊</param>
        /// <param name="queryDto">要查詢的組合產品資訊</param>
        /// <returns></returns>
        /// <response code="200">查詢成功</response>
        /// <response code="400">輸入的參數有誤</response>
        /// <response code="401">身分驗證失敗</response>
        /// <response code="403">權限不足</response>
        /// <response code="500">查詢失敗</response>
        [HttpGet]
        [RequiredAdmin]
        [ProducesResponseType(typeof(PaginationResponse<CompositeProductDto?>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status500InternalServerError)]
        public IActionResult Get(
            [FromQuery] QueryPaginationDto pageDto,
            [FromQuery] QueryCompositeProductDto queryDto)
        {
            return Ok(PaginationResponse<CompositeProductDto?>.GetSuccess(
                pageDto.Page,
                pageDto.PageCount,
                _compositeProductService.Get(queryDto).Select(p => CompositeProductDto.Parse(p)
            )));
        }

        /// <summary>
        /// 根據id查詢組合產品
        /// </summary>
        /// <param name="id">組合產品的id</param>
        /// <returns></returns>
        /// <response code="200">查詢成功</response>
        /// <response code="400">輸入的參數有誤</response>
        /// <response code="401">身分驗證失敗</response>
        /// <response code="403">權限不足</response>
        /// <response code="500">查詢失敗</response>
        [HttpGet("{id}")]
        [RequiredAdmin]
        [ProducesResponseType(typeof(GenericResponse<CompositeProductDto?>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetByIdAsync(long id)
        {
            CompositeProduct? compositeProduct = await _compositeProductService.GetByIdAsync(id);
            return Ok(GenericResponse<CompositeProductDto?>.GetSuccess(CompositeProductDto.Parse(compositeProduct)));
        }

        /// <summary>
        /// 新增組合產品
        /// </summary>
        /// <param name="insertDto">要新增的組合產品資訊</param>
        /// <returns></returns>
        /// <response code="200">新增成功</response>
        /// <response code="400">輸入的參數有誤</response>
        /// <response code="401">身分驗證失敗</response>
        /// <response code="403">權限不足</response>
        /// <response code="500">新增失敗</response>
        [HttpPost]
        [RequiredAdmin]
        [ProducesResponseType(typeof(GenericResponse<CompositeProductDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> InsertAsync([FromBody] InsertCompositeProductDto insertDto)
        {
            return Ok(GenericResponse<CompositeProductDto>
                    .GetSuccess(CompositeProductDto
                        .Parse(await _compositeProductService.InsertAsync(insertDto))
                    )
            );
        }

        /// <summary>
        /// 編輯組合產品
        /// </summary>
        /// <param name="updateDto">要編輯的組合產品資訊</param>
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
        public async Task<IActionResult> UpdateAsync([FromBody] UpdateCompositeProductDto updateDto)
        {
            await _compositeProductService.UpdateAsync(updateDto);
            return Ok(GenericResponse<string>.GetSuccess());
        }

        /// <summary>
        /// 刪除組合產品
        /// </summary>
        /// <param name="id">要刪除的組合產品id</param>
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
            await _compositeProductService.DeleteAsync(id);
            return Ok(GenericResponse<string>.GetSuccess());
        }

        /// <summary>
        /// 啟用組合產品
        /// </summary>
        /// <param name="id">要設定組合啟用的產品id</param>
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
            await _compositeProductService.EnableAsync(id, true);
            return Ok(GenericResponse<string>.GetSuccess());
        }

        /// <summary>
        /// 停用組合產品
        /// </summary>git
        /// <param name="id">要設定停用的組合產品id</param>
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
            await _compositeProductService.EnableAsync(id, false);
            return Ok(GenericResponse<string>.GetSuccess());
        }
    }
}
