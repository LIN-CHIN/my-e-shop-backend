using EShopAPI.Cores.ProductMasters.DTOs;
using EShopAPI.Cores.ProductMasters.Services;
using EShopAPI.Cores.ShopUsers.DTOs;
using EShopAPI.Filters;
using EShopCores.Models;
using EShopCores.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EShopAPI.Cores.ProductMasters
{
    /// <summary>
    /// 產品主檔
    /// </summary>
    [Route("eshop/api/[controller]")]
    [ApiController]
    public class ProductMasterController : ControllerBase
    {
        private readonly IProductMasterService _productMasterService;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="productMasterService"></param>
        public ProductMasterController(IProductMasterService productMasterService) 
        {
            _productMasterService = productMasterService;   
        }

        /// <summary>
        /// 查詢產品主檔清單
        /// </summary>
        /// <param name="pageDto">分頁參數</param>
        /// <param name="queryDto">搜尋條件</param>
        /// <returns></returns>
        [HttpGet()]
        [ProducesResponseType(typeof(PaginationResponse<ProductMasterDto?>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status500InternalServerError)]
        public IActionResult Get(
            [FromQuery] QueryPaginationDto pageDto,
            [FromQuery] QueryProductMasterDto queryDto) 
        {
            return Ok(PaginationResponse<ProductMasterDto?>.GetSuccess(
                pageDto.Page,
                pageDto.PageCount,
                _productMasterService
                    .Get(queryDto)
                    .Select(pm => ProductMasterDto.Parse(pm))
            ));
        }

        /// <summary>
        /// 根據id取得產品主檔
        /// </summary>
        /// <param name="id">產品主檔的id</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(GenericResponse<ProductMasterDto?>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetByIdAsync(long id) 
        {
            return Ok(GenericResponse<ProductMasterDto>.GetSuccess(
                ProductMasterDto.Parse(await _productMasterService.GetByIdAsync(id))
            ));
        }

        /// <summary>
        /// 新增產品主檔
        /// </summary>
        /// <param name="insertDto">要新增的產品主檔資料</param>
        /// <returns></returns>
        /// <response code="200">新增成功</response>
        /// <response code="401">Token驗證失敗</response>
        /// <response code="403">權限不足，驗證失敗</response>
        /// <response code="500">新增失敗</response>
        [HttpPost()]
        [TypeFilter(typeof(RequiredAdminFilter))]
        [ProducesResponseType(typeof(GenericResponse<ProductMasterDto?>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> InsertAsync(InsertProductMasterDto insertDto)
        {
            return Ok(GenericResponse<ProductMasterDto>.GetSuccess(
                ProductMasterDto.Parse(await _productMasterService.InsertAsync(insertDto))
            ));
        }

        /// <summary>
        /// 編輯產品主檔
        /// </summary>
        /// <param name="updateDto">要編輯的產品主檔資料</param>
        /// <returns></returns>
        /// <response code="200">編輯成功</response>
        /// <response code="401">Token驗證失敗</response>
        /// <response code="403">權限不足，驗證失敗</response>
        /// <response code="500">編輯失敗</response>
        [HttpPut()]
        [TypeFilter(typeof(RequiredAdminFilter))]
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateAsync(UpdateProductMasterDto updateDto)
        {
            await _productMasterService.UpdateAsync(updateDto);

            return Ok(GenericResponse<string>.GetSuccess());
        }

        /// <summary>
        /// 啟用產品主檔
        /// </summary>
        /// <returns></returns>
        /// <response code="200">啟用成功</response>
        /// <response code="401">Token驗證失敗</response>
        /// <response code="403">權限不足，驗證失敗</response>
        /// <response code="500">啟用失敗</response>
        [HttpPatch("Enable/{id}")]
        [TypeFilter(typeof(RequiredAdminFilter))]
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> EnableAsync(long id)
        {
            await _productMasterService.EnableAsync(id, true);
            return Ok(GenericResponse<string>.GetSuccess());
        }

        /// <summary>
        /// 停用產品主檔
        /// </summary>
        /// <returns></returns>
        /// <response code="200">停用成功</response>
        /// <response code="401">Token驗證失敗</response>
        /// <response code="403">權限不足，驗證失敗</response>
        /// <response code="500">停用失敗</response>
        [HttpPatch("Disable/{id}")]
        [TypeFilter(typeof(RequiredAdminFilter))]
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DisableAsync(long id)
        {
            await _productMasterService.EnableAsync(id, false);
            return Ok(GenericResponse<string>.GetSuccess());
        }
    }
}
