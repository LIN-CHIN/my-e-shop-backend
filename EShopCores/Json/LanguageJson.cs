using EShopCores.Enums;
using System.Text.Json.Serialization;

namespace EShopCores.Json
{
    /// <summary>
    /// 設定多國語係Json的格式
    /// </summary>
    /// <remarks>
    /// 範例:
    /// [
    ///  {
    ///     "key": "語言的key",
    ///     "value": "該欄位對應的語言名稱"
    ///  },
    ///  {
    ///     "key": "TW",
    ///     "value": "產品名稱" 
    ///  }
    ///]
    /// </remarks>
    public class LanguageJson
    {
        /// <summary>
        /// 語言key
        /// </summary>
        [JsonRequired]
        [JsonPropertyName("key")]
        public LanguageType LanguageKey { get; set; }

        /// <summary>
        /// 語言的值
        /// </summary>
        [JsonRequired]
        [JsonPropertyName("value")]
        public string LanguageValue { get; set; } = null!;
    }
}
