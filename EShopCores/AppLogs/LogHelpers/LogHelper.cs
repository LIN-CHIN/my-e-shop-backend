using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Serilog.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public void WriteBody(string eventId, LogMessageType messageType, object? body)
        {
            LogModel logModel = new LogModel(eventId, messageType, body);
            
            using (LogContext.PushProperty("EventID", eventId, true))
            {
                _logger.LogInformation("{message}", JsonConvert.SerializeObject(logModel));
            }
        }
    }
}
