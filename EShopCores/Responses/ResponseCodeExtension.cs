using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EShopCores.Responses
{
    /// <summary>
    /// ResponseCode 的擴充功能
    /// </summary>
    public static class ResponseCodeExtension
    {
        /// <summary>
        /// 取得ResponseCode的描述
        /// </summary>
        /// <param name="responseCodeType"></param>
        /// <returns></returns>
        public static string GetDescription(this ResponseCodeType responseCodeType)
        {
            Type enumType = typeof(ResponseCodeType);
            string? enumName = Enum.GetName(enumType, responseCodeType);

            if (string.IsNullOrEmpty(enumName)) 
            {
                return string.Empty;
            }

            var attr = enumType.GetField(enumName)!.GetCustomAttributes<ResponseMessageAttribute>().First();
            return attr.Description;
        }

        /// <summary>
		/// 取得ResponseCode的訊息
		/// </summary>
		/// <param name="responseCodeType"></param>
		/// <returns></returns>
		public static string GetMessage(this ResponseCodeType responseCodeType)
        {
            var enumType = typeof(ResponseCodeType);
            string? enumName = Enum.GetName(enumType, responseCodeType);

            if (string.IsNullOrEmpty(enumName))
            {
                return string.Empty;
            }

            var attr = enumType.GetField(enumName)!.GetCustomAttributes<ResponseMessageAttribute>().First();
            return attr.Message;
        }
    }
}
