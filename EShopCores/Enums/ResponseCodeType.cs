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
        #region 系統訊息 (大方向) 0-1000
        /// <summary>
        /// 成功
        /// </summary>
        [Description("成功")]
        [ResponseMessage("Success", Description = "成功")]
        Success = 0,

        /// <summary>
        /// 系統錯誤
        /// </summary>
        [Description("系統錯誤")]
        [ResponseMessage("SystemError", Description = "系統錯誤")]
        SystemError = 1,
        #endregion

        #region 參數問題 1000-1999
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
        #endregion

        #region 資料庫、資料問題  2000-3000

        /// <summary>
        /// DB內部錯誤
        /// </summary>
        [Description("DB內部錯誤")]
        [ResponseMessage("DBInnerError", Description = "DB內部錯誤")]
        DBInnerError = 2000,

        /// <summary>
        /// 違反Unique Key，資料重複
        /// </summary>
        [Description("違反Unique Key，資料重複")]
        [ResponseMessage("UniqueDataDuplicate", Description = "違反Unique Key，資料重複")]
        UniqueDataDuplicate = 2001


        #endregion
    }
}
