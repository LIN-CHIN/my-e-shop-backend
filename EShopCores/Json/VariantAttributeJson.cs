using System.Text.Json.Serialization;

namespace EShopCores.Json
{
    /// <summary>
    /// 變種屬性Json格式
    /// </summary>
    /// <remarks>
    /// 範例:
    /// [
    ///  {
    ///     "key": "custom_variant_attribute 的number",
    ///     "value": "custom_variant_attribute 的options欄位中的id"
    ///  },
    ///  {
    ///     "key": "color",
    ///     "value": "123kopedk00123mweofmwpmo"  //GUID之類的唯一碼()
    ///  }
    ///]
    /// </remarks>
    public class VariantAttributeJson
    {
        /// <summary>
        /// 變種屬性的Key
        /// </summary>
        /// <remarks>
        /// custom_variant_attribute 的number
        /// </remarks>
        [JsonRequired]
        [JsonPropertyName("key")]
        public string Key { get; set; } = null!;

        /// <summary>
        /// 變種屬性的值
        /// </summary>
        /// <remarks>
        /// custom_variant_attribute 的options欄位中的id，
        /// GUID之類的唯一碼()
        /// </remarks>
        [JsonRequired]
        [JsonPropertyName("value")]
        public string Value { get; set; } = null!;
    }
}
