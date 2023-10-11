using EShopAPI.Cores.ProductMasters.DTOs;
using EShopAPI.Cores.ProductMasters.Services;
using EShopAPI.Cores.ShopUsers.DTOs;
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
        [HttpPost()]
        [ProducesResponseType(typeof(GenericResponse<ProductMasterDto?>), StatusCodes.Status200OK)]
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
        [HttpPut()]
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status200OK)]
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
        [HttpPatch("Enable/{id}")]
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status200OK)]
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
        [HttpPatch("Disable/{id}")]
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DisableAsync(long id)
        {
            await _productMasterService.EnableAsync(id, false);
            return Ok(GenericResponse<string>.GetSuccess());
        }
    }
}
