using EShopCores.AppLogs;
using EShopCores.AppLogs.LogHelpers;
using EShopCores.Errors;
using EShopCores.Models;
using Microsoft.IO;
using Newtonsoft.Json;
using System.Net;
using System.Text;

namespace EShopAPI.Middlewares
{
    /// <summary>
    /// 紀錄Log的Middleware
    /// </summary>
    public class LogMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly RecyclableMemoryStreamManager _recyclableMemoryStreamManager;

        public LogMiddleware(RequestDelegate next)
        {
            _next = next;
            _recyclableMemoryStreamManager = new RecyclableMemoryStreamManager();
        }

        public async Task InvokeAsync(HttpContext context)
        {
            //Generate eventId
            string eventId = Guid.NewGuid().ToString();
            context.Items["EventId"] = eventId;

            var _logger = context.RequestServices.GetRequiredService<ILogHelper>();

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
        private static async Task<object?> GetRequestBody(HttpRequest request)
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
            var originalBodyStream = context.Response.Body;
            await using var responseBody = _recyclableMemoryStreamManager.GetStream();
            context.Response.Body = responseBody;

            await _next(context);

            context.Response.Body.Seek(0, SeekOrigin.Begin);
            var body = await new StreamReader(responseBody).ReadToEndAsync();
            context.Response.Body.Seek(0, SeekOrigin.Begin);
            await responseBody.CopyToAsync(originalBodyStream);

            return JsonConvert.DeserializeObject(body);
        }
    }
}
