using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShopCores.AppLogs
{
    /// <summary>
    /// Log訊息類型
    /// </summary>
    public enum LogMessageType
    {
        /// <summary>
        /// 請求時記錄的Log
        /// </summary>
        [Description("請求時記錄的Log")]
        Request = 1,

        /// <summary>
        /// 回應時紀錄的Log
        /// </summary>
        [Description("回應時紀錄的Log")]
        Response = 2
    }
}
