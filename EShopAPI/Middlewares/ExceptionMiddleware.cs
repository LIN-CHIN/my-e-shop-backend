using EShopCores.Errors;
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

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="next"></param>
        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        /// <summary>
        /// Invoke
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task InvokeAsync(HttpContext context)
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

            GenericResponse<string> result;

            //處理DB相關的錯誤
            if (exception.GetBaseException() is PostgresException pgException)
            {
                result = HandlePostgresException(pgException);
               
            }
            else if (exception is EShopException eshopException) 
            {
                result = GenericResponse<string>.GetResult(
                        eshopException.Code,
                        exception.ToString())!;
            }
            else
            {
                result = GenericResponse<string>.GetResult(
                    ResponseCodeType.SystemError,
                    exception.ToString())!;
            }
            
            await context.Response.WriteAsJsonAsync(result);
        }

        /// <summary>
		/// 專門處理PostgresException
		/// </summary>
		/// <param name="exception"></param>
		/// <returns></returns>
		private static GenericResponse<string> HandlePostgresException(PostgresException exception)
        {
            //違反Unique Key
            if (exception.SqlState == "23505")
            {
                return GenericResponse<string>.GetResult(
                        ResponseCodeType.UniqueDataDuplicate,
                        exception.ToString())!;
            }
            //違反FK
            else if (exception.SqlState == "23503")
            {
                return GenericResponse<string>.GetResult(
                        ResponseCodeType.DbForeignKeyViolation,
                        exception.ToString())!;
            }
            //其他錯誤
            else
            {
                return GenericResponse<string>.GetResult(
                         ResponseCodeType.DBInnerError,
                         exception.ToString())!;
            }
        }
    }
}