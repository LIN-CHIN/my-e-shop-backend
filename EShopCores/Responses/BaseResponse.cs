using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShopCores.Responses
{
    /// <summary>
    /// Response 基底物件
    /// </summary>
    public abstract class BaseResponse
    {
        /// <summary>
        /// 代碼
        /// </summary>
        [JsonProperty(Order = 0)]
        public ResponseCodeType Code { get; set; }

        /// <summary>
        /// Response代表的訊息
        /// </summary>
        [JsonProperty(Order = 1)]
        public string Message { get; set; } = string.Empty;

        /// <summary>
        /// Code的中文描述 或 補充提示訊息
        /// </summary>
        [JsonProperty(Order = 2)]
        public string Description { get; set; } = string.Empty;
    }
}
