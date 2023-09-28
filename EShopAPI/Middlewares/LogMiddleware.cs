using EShopCores.AppLogs;
using EShopCores.AppLogs.LogHelpers;
using Microsoft.IO;
using System.Text;
using System.Text.Json;

namespace EShopAPI.Middlewares
{
    /// <summary>
    /// 紀錄Log的Middleware
    /// </summary>
    public class LogMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly RecyclableMemoryStreamManager _recyclableMemoryStreamManager;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="next"></param>
        public LogMiddleware(RequestDelegate next)
        {
            _next = next;
            _recyclableMemoryStreamManager = new RecyclableMemoryStreamManager();
        }

        /// <summary>
        /// Invoke
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task InvokeAsync(HttpContext context)
        {
            //Generate eventId
            string eventId = Guid.NewGuid().ToString();
            context.Items["EventId"] = eventId;

            var _logger = context.RequestServices.GetRequiredService<ILogHelper>();

            string? requestBody = await GetRequestBody(context.Request);
            _logger.WriteBody(eventId, LogMessageType.Request, requestBody);

            string? responseBody = await GetResponseBody(context);
            _logger.WriteBody(eventId, LogMessageType.Response, responseBody);
        }

        /// <summary>
        /// 取得Request body 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        private static async Task<string?> GetRequestBody(HttpRequest request)
        {
            request.EnableBuffering();

            using (StreamReader reader = new StreamReader(
                request.Body,
                Encoding.UTF8,
                detectEncodingFromByteOrderMarks: false,
                leaveOpen: true))
            {
                string? body = await reader.ReadToEndAsync();
                request.Body.Position = 0;
                return body;
            }
        }

        /// <summary>
        /// 取得Response body
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private async Task<string?> GetResponseBody(HttpContext context)
        {
            var originalBodyStream = context.Response.Body;
            await using var responseBody = _recyclableMemoryStreamManager.GetStream();
            context.Response.Body = responseBody;

            await _next(context);

            context.Response.Body.Seek(0, SeekOrigin.Begin);
            var body = await new StreamReader(responseBody).ReadToEndAsync();
            context.Response.Body.Seek(0, SeekOrigin.Begin);
            await responseBody.CopyToAsync(originalBodyStream);

            return body;
        }
    }
}
