using System.Text.Json.Serialization;

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
        [JsonPropertyOrder(0)]
        public ResponseCodeType Code { get; set; }

        /// <summary>
        /// Response代表的訊息
        /// </summary>
        [JsonPropertyOrder(1)]
        public string Message { get; set; } = string.Empty;

        /// <summary>
        /// Code的中文描述 或 補充提示訊息
        /// </summary>
        [JsonPropertyOrder(2)]
        public string Description { get; set; } = string.Empty;
    }
}
