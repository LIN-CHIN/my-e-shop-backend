using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShopCores.Enums
{
    /// <summary>
    /// 語言類型
    /// </summary>
    public enum LanguageType
    {
        /// <summary>
        /// 台灣(繁體中文)
        /// </summary>
        [Description("台灣(繁體中文)")]
        TW = 1,

        /// <summary>
        /// 英文
        /// </summary>
        [Description("英文")]
        EN_US = 2,
    }
}
