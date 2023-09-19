using EShopCores.Errors;
using EShopCores.Models;
using EShopCores.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        /// <summary>
        /// 測試
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post([FromBody]string a) 
        {
            throw new ExceptionHandler(ResponseCodeType.RequestParameterError, "參數測試錯誤");
           
            return Ok(new ResponseModel<string> 
            {
                Code = ResponseCodeType.Success,
                
            });
        }
    }
}
