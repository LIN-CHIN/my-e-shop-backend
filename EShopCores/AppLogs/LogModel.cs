using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShopCores.AppLogs
{
    /// <summary>
    /// 紀錄Log用的Model
    /// </summary>
    public class LogModel
    {
        /// <summary>
        /// 事件id
        /// </summary>
        public string EventId { get; private set; } = null!;

        /// <summary>
        /// 訊息類型
        /// </summary>
        public LogMessageType LogMessageType { get; private set; }

        /// <summary>
        /// Request/Response Body
        /// </summary>
        public object? Body { get; private set; }

        /// <summary>
        /// Costructor
        /// </summary>
        /// <param name="eventId">事件id</param>
        /// <param name="logMessageType">訊息類型</param>
        /// <param name="body">Request/Response Body</param>
        public LogModel(string eventId,
                        LogMessageType logMessageType,
                        object? body)
        {
            EventId = eventId;
            LogMessageType = logMessageType;
            Body = body;
        }
    }
}
