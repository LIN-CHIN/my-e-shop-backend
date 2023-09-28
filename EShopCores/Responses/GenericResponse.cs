using EShopCores.Errors;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShopCores.Responses
{
    /// <summary>
    /// 通用的Response Class
    /// </summary>
    public class GenericResponse<T> : BaseResponse
    {
        /// <summary>
        /// 回傳內容
        /// </summary>
        [JsonProperty(Order = 3)]
        public T? Content { get; set; }

        /// <summary>
        /// 取得最後的結果 (Exception訊息)
        /// </summary>
        /// <param name="code"></param>
        /// <param name="description">exception錯誤訊息</param>
        /// <param name="content"></param>
        public static GenericResponse<T?> GetResult(
            ResponseCodeType code,
            string description,
            T? content)
        {
            return new GenericResponse<T?>
            {
                Code = code,
                Message = code.GetMessage(),
                Description = description,
                Content = content
            };
        }

        /// <summary>
        /// 取得最後的結果
        /// </summary>
        /// <param name="code"></param>
        /// <param name="content"></param>
        public static GenericResponse<T?> GetResult(ResponseCodeType code, T? content)
        {
            return new GenericResponse<T?>
            {
                Code = code,
                Message = code.GetMessage(),
                Description = code.GetDescription(),
                Content = content
            };
        }

        /// <summary>
        /// 取得成功結果
        /// </summary>
        /// <param name="content"></param>
        public static GenericResponse<T?> GetSuccess(T? content)
        {
            return new GenericResponse<T?>
            {
                Code = ResponseCodeType.Success,
                Message = ResponseCodeType.Success.GetMessage(),
                Description = ResponseCodeType.Success.GetDescription(),
                Content = content
            };
        }

        /// <summary>
        /// 取得成功結果(沒有任何要回傳的資料)
        /// </summary>
        public static GenericResponse<T?> GetSuccess()
        {
            return new GenericResponse<T?>
            {
                Code = ResponseCodeType.Success,
                Message = ResponseCodeType.Success.GetMessage(),
                Description = ResponseCodeType.Success.GetDescription(),
                Content = default
            };
        }
    }
}
