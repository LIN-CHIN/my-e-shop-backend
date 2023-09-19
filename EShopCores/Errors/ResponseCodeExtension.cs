using EShopCores.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EShopCores.Errors
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
            var enumType = typeof(ResponseCodeType);
            var enumName = Enum.GetName(enumType, responseCodeType);
            var attr = enumType.GetField(enumName).GetCustomAttributes<ResponseMessageAttribute>().First();
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
            var enumName = Enum.GetName(enumType, responseCodeType);
            var attr = enumType.GetField(enumName).GetCustomAttributes<ResponseMessageAttribute>().First();
            return attr.Message;
        }
    }
}
