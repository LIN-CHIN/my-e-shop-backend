using EShopCores.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShopCores.Models
{
    /// <summary>
    /// Response Model
    /// </summary>
    public class ResponseModel<T>
    {
        /// <summary>
        /// 代碼
        /// </summary>
        public ResponseCodeType Code { get; set; }

        /// <summary>
        /// Response代表的訊息
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Response的中文描述
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 回傳內容
        /// </summary>
        public T Content { get; set; }
    }
}
