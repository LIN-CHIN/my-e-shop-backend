using EShopCores.Responses;
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
        private static async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = StatusCodes.Status500InternalServerError;

            ResponseModel<string> result = new ResponseModel<string>();

            //處理DB相關的錯誤
            if (exception.InnerException != null)
            {
                //違反Unique Key
                if (((PostgresException)exception.InnerException).SqlState == "23505")
                {
                    result = ResponseModel<string>.GetResult(
                        ResponseCodeType.UniqueDataDuplicate,
                        exception.ToString());
                }
                //違反FK
                else if (((PostgresException)exception.InnerException).SqlState == "23503")
                {
                    result = ResponseModel<string>.GetResult(
                        ResponseCodeType.UniqueDataDuplicate,
                        exception.ToString());
                }
                else
                {
                    result = ResponseModel<string>.GetResult(
                        ResponseCodeType.DBInnerError,
                        exception.ToString());
                }
            }
            else 
            {
                result = ResponseModel<string>.GetResult(
                    ResponseCodeType.SystemError,
                    exception.ToString());
            }
            
            await context.Response.WriteAsJsonAsync(result);
        }
    }
}
