using EShopCores.Errors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShopCores.Enums
{
    /// <summary>
    /// Response 代碼類型
    /// </summary>
    public enum ResponseCodeType
    {
        /// <summary>
        /// 成功
        /// </summary>
        [Description("成功")]
        [ResponseMessage("Success", Description = "成功")]
        Success = 0,

        /// <summary>
        /// Request參數錯誤
        /// </summary>
        [Description("Request參數錯誤")]
        [ResponseMessage("RequestParameter", Description = "Request參數錯誤")]
        RequestParameter = 1000,

        /// <summary>
        /// ModelBinding錯誤
        /// </summary>
        [Description("ModelBinding錯誤")]
        [ResponseMessage("ModelBindingError", Description = "ModelBinding錯誤")]
        ModelBindingError = 1001,
    }
}
