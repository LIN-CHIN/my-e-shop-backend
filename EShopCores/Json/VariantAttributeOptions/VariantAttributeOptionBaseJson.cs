using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EShopCores.Json.VariantAttributeOptions
{
    /// <summary>
    /// 變種選項通用的json格式
    /// </summary>
    /// <remarks>
    /// [
    ///   {
    ///       "id": "GUID()",
    ///       "name": "紅色"
    ///   },
    ///   {
    ///       "id": "GUID()",
    ///       "name": "藍色"
    ///   }
    /// ]
    /// </remarks>
    public class VariantAttributeOptionBaseJson
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
    }
}
