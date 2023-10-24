using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EShopCores.Json.VariantAttributeOptions
{
    /// <summary>
    /// 變種屬性選項(數字)的json格式
    /// </summary>
    /// <remarks>
    /// [
    ///  {
    ///      "id": "GUID()",
    ///      "name": 1,
    ///  }
    /// ]
    /// </remarks>
    public class VariantAttributeOptionNumberJson
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
        public long Name { get; set; }
    }
}
