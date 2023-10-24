using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EShopCores.Json.VariantAttributeOptions
{
    /// <summary>
    /// 變種屬性選項(顏色)的json格式
    /// </summary>
    /// <remarks>
    /// [
    ///   {
    ///       "id": "GUID()",
    ///       "name": "紅色",
    ///       "hex": "#FFFFFF"
    ///   },
    ///   {
    ///       "id": "GUID()",
    ///       "name": "藍色",
    ///       "hex": "#FFFFFF"
    ///   }
    /// ]
    /// </remarks>
    public class VariantAttributeOptionColorJson
    {
        /// <summary>
        /// 唯一值
        /// </summary>
        [JsonRequired]
        [JsonPropertyName("id")]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        /// <summary>
        /// 變種屬性選項名稱
        /// </summary>
        [JsonRequired]
        [JsonPropertyName("name")]
        public string Name { get; set; } = null!;

        /// <summary>
        /// 色碼
        /// </summary>
        [JsonRequired]
        [JsonPropertyName("hex")]
        public string Hex { get; set; } = null!;
    }
}
