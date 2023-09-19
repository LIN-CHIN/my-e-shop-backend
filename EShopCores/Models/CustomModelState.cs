using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShopCores.Models
{
    /// <summary>
    /// 自訂 ModelState 的回傳格式
    /// </summary>
    public class CustomModelState
    {
        /// <summary>
        /// 錯誤的Key，通常是Property name
        /// </summary>
        public string? Key { get; set; }

        /// <summary>
        /// 錯誤訊息
        /// </summary>
        public string? ErrorMessage { get; set; }
    }
}
