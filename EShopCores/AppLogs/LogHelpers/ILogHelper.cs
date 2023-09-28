﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShopCores.AppLogs.LogHelpers
{
    /// <summary>
    /// LogHelper Interface
    /// </summary>
    public interface ILogHelper
    {
        /// <summary>
        /// 紀錄info log
        /// </summary>
        /// <param name="message"></param>
        void WriteInfoLog(string message);

        /// <summary>
        /// 紀錄info + 事件id
        /// </summary>
        /// <param name="message">訊息</param>
        /// <param name="eventId">事件id</param>
        void WriteInfoLog(string message, string eventId);

        /// <summary>
        /// 紀錄error log
        /// </summary>
        /// <param name="message"></param>
        void WriteErrorLog(string message);

        /// <summary>
        /// 紀錄error + 事件id
        /// </summary>
        /// <param name="message">訊息</param>
        /// <param name="eventId">事件id</param>
        void WriteErrorLog(string message, string eventId);

        /// <summary>
        /// 將body轉成LogModel後 記錄log
        /// </summary>
        /// <param name="eventId">事件id</param>
        /// <param name="messageType">訊息類型</param>
        /// <param name="body"></param>
        void WriteBody(string eventId, LogMessageType messageType, string? body);
    }
}
