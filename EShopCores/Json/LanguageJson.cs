using EShopCores.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EShopCores.Json
{
    /// <summary>
    /// 設定多國語係Json的格式
    /// </summary>
    public class LanguageJson
    {
        /// <summary>
        /// 語言key
        /// </summary>
        [JsonRequired]
        public LanguageType LanguageKey { get; set; }

        /// <summary>
        /// 語言的值
        /// </summary>
        [JsonRequired]
        public string LanguageValue { get; set; } = null!;
    }
}
