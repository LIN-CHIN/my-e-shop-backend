using EShopCores.Enums;
using EShopCores.LogHelpers;
using Microsoft.IO;
using Newtonsoft.Json;
using System.Text;

namespace EShopAPI.Middlewares
{
    /// <summary>
    /// 紀錄Log的Middleware
    /// </summary>
    public class LogMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogHelper _logger;
        private readonly RecyclableMemoryStreamManager _recyclableMemoryStreamManager;

        public LogMiddleware(RequestDelegate next, ILogHelper logger)
        {
            _next = next;
            _logger = logger;
            _recyclableMemoryStreamManager = new RecyclableMemoryStreamManager();
        }

        public async Task InvokeAsync(HttpContext context)
        {
            string eventId = context.Request.Headers["EventId"].ToString();
            if (string.IsNullOrWhiteSpace(eventId))
            {
                throw new ArgumentException("Header一定要有EventId");
            }

            object? requestBody = await GetRequestBody(context.Request);
            _logger.WriteBody(eventId, LogMessageType.Request, JsonConvert.SerializeObject(requestBody));

            object? responseBody = await GetResponseBody(context);
            _logger.WriteBody(eventId, LogMessageType.Response, JsonConvert.SerializeObject(responseBody));

        }

        /// <summary>
        /// 取得Request body 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        private async Task<object?> GetRequestBody(HttpRequest request)
        {
            request.EnableBuffering();

            using (StreamReader reader = new StreamReader(
                request.Body,
                Encoding.UTF8,
                detectEncodingFromByteOrderMarks: false,
                leaveOpen: true))
            {
                string body = await reader.ReadToEndAsync();
                request.Body.Position = 0;
                return JsonConvert.DeserializeObject(body);
            }
        }

        /// <summary>
        /// 取得Response body
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private async Task<object?> GetResponseBody(HttpContext context)
        {
            await using var responseBody = _recyclableMemoryStreamManager.GetStream();
            context.Response.Body = responseBody;

            await _next(context);

            context.Response.Body.Seek(0, SeekOrigin.Begin);
            var body = await new StreamReader(responseBody).ReadToEndAsync();
            context.Response.Body.Seek(0, SeekOrigin.Begin);

            return JsonConvert.DeserializeObject(body);
        }
    }
}
