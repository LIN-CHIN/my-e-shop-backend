using EShopCores.Enums;
using EShopCores.Errors;
using EShopCores.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Npgsql;

namespace EShopAPI.Middlewares
{
    /// <summary>
    /// 負責捕捉Exception 的Middleware
    /// </summary>
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception exception)
            {
                await HandleExceptionAsync(context, exception);
            }
        }

        /// <summary>
        /// 處理Exception
        /// </summary>
        /// <param name="context"></param>
        /// <param name="exception"></param>
        /// <returns></returns>
        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = StatusCodes.Status500InternalServerError;
            
            //處理DB相關的錯誤
            if (exception.InnerException != null)
            {
                //違反Unique Key
                if (((PostgresException)exception.InnerException).SqlState == "23505")
                {
                    return context.Response.WriteAsync(
                        JsonConvert.SerializeObject( new ResponseModel<string>
                        {
                            Code = ResponseCodeType.UniqueDataDuplicate,
                            Message = ResponseCodeType.UniqueDataDuplicate.GetMessage(),
                            Description = ResponseCodeType.UniqueDataDuplicate.GetDescription(),
                            Content = exception.ToString()
                        })
                    );
                }
                else
                {
                    return context.Response.WriteAsync(
                        JsonConvert.SerializeObject(new ResponseModel<string>
                        {
                            Code = ResponseCodeType.DBInnerError,
                            Message = ResponseCodeType.DBInnerError.GetMessage(),
                            Description = ResponseCodeType.DBInnerError.GetDescription(),
                            Content = exception.ToString()
                        })
                    );
                }
            }

            return context.Response.WriteAsync(
                JsonConvert.SerializeObject(new ResponseModel<string>
                {
                    Code = ResponseCodeType.SystemError,
                    Message = ResponseCodeType.SystemError.GetMessage(),
                    Description = ResponseCodeType.SystemError.GetDescription(),
                    Content = exception.ToString()
                })
            );
        }
    }
}
