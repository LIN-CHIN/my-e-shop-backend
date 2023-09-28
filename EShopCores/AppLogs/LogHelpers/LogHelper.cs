using Microsoft.Extensions.Logging;
using Serilog.Context;
using System.Text.Json;

namespace EShopCores.AppLogs.LogHelpers
{
    public class LogHelper : ILogHelper
    {
        private readonly ILogger<LogHelper> _logger;

        public LogHelper(ILogger<LogHelper> logger)
        {
            _logger = logger;
        }

        ///<inheritdoc/>
        public void WriteInfoLog(string message)
        {
            _logger.LogInformation("{message}", message);
        }

        ///<inheritdoc/>
        public void WriteInfoLog(string message, string eventId)
        {
            using (LogContext.PushProperty("EventID", eventId, true))
            {
                _logger.LogInformation("{message}", message);
            }
        }

        ///<inheritdoc/>
        public void WriteErrorLog(string message)
        {
            _logger.LogError("{message}", message);
        }

        ///<inheritdoc/>
        public void WriteErrorLog(string message, string eventId)
        {
            using (LogContext.PushProperty("EventID", eventId, true))
            {
                _logger.LogError("{message}", message);
            }
        }

        ///<inheritdoc/>
        public void WriteBody(string eventId, LogMessageType messageType, string? body)
        {
            LogModel logModel;

            if (string.IsNullOrWhiteSpace(body))
            {
                logModel = new LogModel(eventId, messageType, "");
            }
            else 
            {
                logModel = new LogModel(
                    eventId,
                    messageType,
                    JsonSerializer.Deserialize<object?>(body));
            }
            
            
            using (LogContext.PushProperty("EventID", eventId, true))
            {
                _logger.LogInformation("{message}", JsonSerializer.Serialize(logModel));
            }
        }
    }
}
