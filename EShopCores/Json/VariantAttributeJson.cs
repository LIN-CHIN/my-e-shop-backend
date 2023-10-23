using System.Text.Json.Serialization;

namespace EShopCores.Json
{
    /// <summary>
    /// 變種屬性Json格式
    /// </summary>
    public class VariantAttributeJson
    {
        /// <summary>
        /// 變種屬性的Key
        /// ex: color
        /// </summary>
        [JsonRequired]
        public string Key { get; set; } = null!;

        /// <summary>
        /// 變種屬性的值
        /// ex: red
        /// </summary>
        [JsonRequired]
        public string Value { get; set; } = null!;
    }
}
