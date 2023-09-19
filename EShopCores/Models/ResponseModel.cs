using EShopCores.Enums;
using EShopCores.Errors;
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

        /// <summary>
        /// 取得最後的結果
        /// </summary>
        /// <param name="code"></param>
        /// <param name="content"></param>
        public static ResponseModel<T> GetResult(ResponseCodeType code, T content)
        {
            return new ResponseModel<T>
            {
                Code = code,
                Message = code.GetMessage(),
                Description = code.GetDescription(),
                Content = content
            };
        }
    }
}
