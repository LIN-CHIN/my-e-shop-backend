using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShopCores.Responses
{
    /// <summary>
    /// 自訂Response訊息屬性
    /// </summary>
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public class ResponseMessageAttribute : Attribute
    {
        /// <summary>
        /// Response描述
        /// </summary>
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// Response訊息
        /// </summary>
        public string Message { get; private set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="message">Response訊息</param>
        public ResponseMessageAttribute(string message)
        {
            Message = message;
        }
    }
}
