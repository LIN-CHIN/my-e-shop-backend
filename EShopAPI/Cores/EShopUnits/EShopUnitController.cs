using EShopAPI.Filters.RequiredAdminFilters;
using EShopCores.Models;
using EShopCores.Responses;
using Microsoft.AspNetCore.Mvc;
using EShopAPI.Cores.EShopUnits.DTOs;
using EShopAPI.Cores.EShopUnits.Services;

namespace EShopAPI.Cores.EShopUnits
{
    /// <summary>
    /// 商店單位API
    /// </summary>
    [Route("eshop/api/[controller]")]
    [ApiController]
    public class EShopUnitController : ControllerBase
    {
        private readonly IEShopUnitService _eShopUnitService;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="eShopUnitService"></param>
        public EShopUnitController(IEShopUnitService eShopUnitService) 
        {
            _eShopUnitService = eShopUnitService;
        }

        /// <summary>
        /// 查詢所有商店單位
        /// </summary>
        /// <param name="pageDto">分頁資訊</param>
        /// <param name="queryDto">要查詢的商店單位資訊</param>
        /// <returns></returns>
        /// <response code="200">查詢成功</response>
        /// <response code="400">輸入的參數有誤</response>
        /// <response code="401">身分驗證失敗</response>
        /// <response code="403">權限不足</response>
        /// <response code="500">查詢失敗</response>
        [HttpGet]
        [RequiredAdmin]
        [ProducesResponseType(typeof(PaginationResponse<EShopUnitDto?>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status500InternalServerError)]
        public IActionResult Get(
            [FromQuery] QueryPaginationDto pageDto,
            [FromQuery] QueryEShopUnitDto queryDto)
        {
            return Ok(PaginationResponse<EShopUnitDto?>.GetSuccess(
                pageDto.Page,
                pageDto.PageCount,
                _eShopUnitService.Get(queryDto).Select(e => EShopUnitDto.Parse(e)
            )));
        }

        /// <summary>
        /// 根據id查詢商店單位
        /// </summary>
        /// <param name="id">商店單位的id</param>
        /// <returns></returns>
        /// <response code="200">查詢成功</response>
        /// <response code="400">輸入的參數有誤</response>
        /// <response code="401">身分驗證失敗</response>
        /// <response code="403">權限不足</response>
        /// <response code="500">查詢失敗</response>
        [HttpGet("{id}")]
        [RequiredAdmin]
        [ProducesResponseType(typeof(GenericResponse<EShopUnitDto?>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetByIdAsync(long id)
        {
            EShopUnit? eShopUnit = await _eShopUnitService.GetByIdAsync(id);
            return Ok(GenericResponse<EShopUnitDto?>.GetSuccess(EShopUnitDto.Parse(eShopUnit)));
        }

        /// <summary>
        /// 新增商店單位
        /// </summary>
        /// <param name="insertDto">要新增的商店單位資訊</param>
        /// <returns></returns>
        /// <response code="200">新增成功</response>
        /// <response code="400">輸入的參數有誤</response>
        /// <response code="401">身分驗證失敗</response>
        /// <response code="403">權限不足</response>
        /// <response code="500">新增失敗</response>
        [HttpPost]
        [RequiredAdmin]
        [ProducesResponseType(typeof(GenericResponse<EShopUnitDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> InsertAsync([FromBody] InsertEShopUnitDto insertDto)
        {
            return Ok(GenericResponse<EShopUnitDto>
                    .GetSuccess(EShopUnitDto
                        .Parse(await _eShopUnitService.InsertAsync(insertDto))
                )
            );
        }

        /// <summary>
        /// 編輯商店單位
        /// </summary>
        /// <param name="updateDto">要編輯的商店單位資訊</param>
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
        public async Task<IActionResult> UpdateAsync([FromBody] UpdateEShopUnitDto updateDto)
        {
            await _eShopUnitService.UpdateAsync(updateDto);
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
            await _eShopUnitService.EnableAsync(id, true);
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
            await _eShopUnitService.EnableAsync(id, false);
            return Ok(GenericResponse<string>.GetSuccess());
        }
    }
}
