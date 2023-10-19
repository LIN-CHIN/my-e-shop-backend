namespace EShopAPI.Common.Json
{
    /// <summary>
    /// 用來定義產品主檔設定變種屬性時的Json格式
    /// </summary>
    public class VariantAttributeJson
    {
        /// <summary>
        /// 屬性的key
        /// </summary>
        [JsonRequired]
        public string AttributeKey { get; set; } = null!;

        /// <summary>
        /// 屬性可以設定哪些值
        /// </summary>
        [JsonRequired]
        public IEnumerable<string> AttributeValue { get; set; } = new List<string>();
    }
}
