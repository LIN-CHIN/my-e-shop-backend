using EShopAPI.Cores.ShopRoles.DTOs;
using EShopAPI.Cores.ShopRoles.Services;
using EShopCores.Models;
using EShopCores.Responses;
using Microsoft.AspNetCore.Mvc;

namespace EShopAPI.Cores.ShopRoles
{
    /// <summary>
    /// 角色 API
    /// </summary>
    [Route("eshop/api/[controller]")]
    [ApiController]
    public class ShopRoleController : ControllerBase
    {
        private readonly IShopRoleService _shopRoleService;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="shopRoleService"></param>
        public ShopRoleController(IShopRoleService shopRoleService) 
        {
            _shopRoleService = shopRoleService;
        }

        /// <summary>
        /// 取得商店角色
        /// </summary>
        /// <param name="pageDto"></param>
        /// <param name="queryDto"></param>
        /// <response code="200">查詢成功</response>
        /// <response code="500">查詢失敗</response>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(PaginationResponse<ShopRoleDto?>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status500InternalServerError)]
        public IActionResult Get(
            [FromQuery] QueryPaginationDto pageDto,
            [FromQuery] QueryShopRoleDto queryDto) 
        {
            return Ok(PaginationResponse<ShopRoleDto?>.GetSuccess(
                pageDto.Page,
                pageDto.PageCount,
                _shopRoleService.Get(queryDto).Select(role => ShopRoleDto.Parse(role))
            ));
        }

        /// <summary>
        /// 根據id取得角色
        /// </summary>
        /// <param name="id">角色id</param>
        /// <response code="200">查詢成功</response>
        /// <response code="500">查詢失敗</response>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(GenericResponse<ShopRoleDto?>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetById(long id)
        {
            return Ok(GenericResponse<ShopRoleDto>.GetSuccess(
                ShopRoleDto.Parse(await _shopRoleService.GetByIdAsync(id)
            )));
        }

        /// <summary>
        /// 新增商店角色
        /// </summary>
        /// <param name="insertDto"></param>
        /// <response code="200">新增成功</response>
        /// <response code="500">新增失敗</response>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(GenericResponse<ShopRoleDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Insert(InsertShopRoleDto insertDto) 
        {
            return Ok(GenericResponse<ShopRoleDto>.GetSuccess(
                ShopRoleDto.Parse(await _shopRoleService.InsertAsync(insertDto))
            ));
        }

        /// <summary>
        /// 修改商店角色
        /// </summary>
        /// <param name="updateDto"></param>
        /// <response code="200">修改成功</response>
        /// <response code="500">修改失敗</response>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Update(UpdateShopRoleDto updateDto)
        {
            await _shopRoleService.UpdateAsync(updateDto);
            return Ok(GenericResponse<string>.GetSuccess());
        }

        /// <summary>
        /// 啟用角色
        /// </summary>
        /// <param name="id">要啟用的角色id</param>
        /// <response code="200">修改成功</response>
        /// <response code="500">修改失敗</response>
        /// <returns></returns>
        [HttpPatch("Enable/{id}")]
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Enable(long id)
        {
            await _shopRoleService.EnableAsync(id, true);
            return Ok(GenericResponse<string>.GetSuccess());
        }

        /// <summary>
        /// 停用角色
        /// </summary>
        /// <param name="id">要停用的角色id</param>
        /// <response code="200">修改成功</response>
        /// <response code="500">修改失敗</response>
        /// <returns></returns>
        [HttpPatch("Disable/{id}")]
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Disable(long id)
        {
            await _shopRoleService.EnableAsync(id, false);
            return Ok(GenericResponse<string>.GetSuccess());
        }
    }
}
