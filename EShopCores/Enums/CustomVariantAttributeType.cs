using System.ComponentModel;
namespace EShopCores.Enums
{
    /// <summary>
    /// 自訂變種屬性的類型
    /// </summary>
    public enum CustomVariantAttributeType
    {
        /// <summary>
        /// 文字類型
        /// </summary>
        [Description("文字類型")]
        Text = 1,

        /// <summary>
        /// 數字類型
        /// </summary>
        [Description("數字類型")]
        Number = 2,

        /// <summary>
        /// 顏色類型
        /// </summary>
        [Description("顏色類型")]
        Color = 3
    }
}
