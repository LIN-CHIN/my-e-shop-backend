using System.Text.Json.Serialization;

namespace EShopCores.Json.VariantAttributeOptions
{
    /// <summary>
    /// 變種屬性選項(文字)的json格式
    /// </summary>
    /// <remarks>
    /// [
    ///  {
    ///      "id": "GUID()",
    ///      "name": "S",
    ///  }
    /// ]
    /// </remarks>
    public class VariantAttributeOptionTextJson
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
