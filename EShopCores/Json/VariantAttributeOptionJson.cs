using System.Text.Json.Serialization;

namespace EShopCores.Json
{
    /// <summary>
    /// 變種屬性選項的json格式
    /// </summary>
    /// <remarks>
    /// [
    ///   {
    ///       "id": "GUID()",
    ///       "name": "紅色",
    ///       "value": "#FFFFFF"
    ///   },
    ///   {
    ///       "id": "GUID()",
    ///       "name": "S",
    ///       "value": "S"
    ///   },
    ///   {
    ///       "id": "GUID()",
    ///       "name": "1",
    ///       "value": "1"
    ///   }
    /// ]
    /// </remarks>
    public class VariantAttributeOptionJson
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
        /// <remarks>
        /// 目前規劃該欄位定義是在選擇該屬性的選項時
        /// 下拉選單出現的名稱
        /// </remarks>
        [JsonRequired]
        [JsonPropertyName("name")]
        public string Name { get; set; } = null!;

        /// <summary>
        /// 變種屬性選項值
        /// </summary>
        /// <remarks>
        /// 使用時需根據CustomVariantAttribute的attribute_type
        /// 來判斷值是什麼類型
        /// ex : 數字 > 需要將value解析成數字計算
        ///      顏色 > 該值就會儲存色碼 #FFFFFF
        /// 目前規畫該欄位會用在要顯示自訂屬性的地方，
        /// 例如: 將產品放入購物車，會顯示 "色碼" or "XL"
        /// </remarks>
        [JsonRequired]
        [JsonPropertyName("value")]
        public string Value { get; set; } = null!;
    }
}
