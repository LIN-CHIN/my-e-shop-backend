using EShopCores.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShopCores.Models
{
    /// <summary>
    /// 紀錄Log用的Model
    /// </summary>
    public class LogModel
    {
        /// <summary>
        /// 事件id
        /// </summary>
        public string EventId { get; set; }

        /// <summary>
        /// 訊息類型
        /// </summary>
        public LogMessageType LogMessageType { get; set; }

        /// <summary>
        /// Request/Response Body
        /// </summary>
        public object? Body { get; set; }
    }
}
