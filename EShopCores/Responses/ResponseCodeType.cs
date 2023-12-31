﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EShopCores.Errors;

namespace EShopCores.Responses
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
        [ResponseMessage("RequestParameterError", Description = "Request參數錯誤")]
        RequestParameterError = 1000,

        /// <summary>
        /// ModelBinding錯誤
        /// </summary>
        [Description("ModelBinding錯誤")]
        [ResponseMessage("ModelBindingError", Description = "ModelBinding錯誤")]
        ModelBindingError = 1001,

        /// <summary>
        /// EventId不可為空
        /// </summary>
        [Description("EventId不可為空")]
        [ResponseMessage("EventIdNullError", Description = "EventId不可為空")]
        EventIdNullError = 1002,

        /// <summary>
        /// 資料重複
        /// </summary>
        [Description("資料重複")]
        [ResponseMessage("DuplicateData", Description = "資料重複")]
        DuplicateData = 1003,

        /// <summary>
        /// 帳號不存在
        /// </summary>
        [Description("帳號不存在")]
        [ResponseMessage("NotFindAccount", Description = "帳號不存在")]
        NotFindAccount = 1004,

        /// <summary>
        /// 密碼錯誤
        /// </summary>
        [Description("密碼錯誤")]
        [ResponseMessage("PwdError", Description = "密碼錯誤")]
        PwdError = 1005,
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
        UniqueDataDuplicate = 2001,

        /// <summary>
        /// 違反ForeignKey
        /// </summary>
        [Description("違反ForeignKey")]
        [ResponseMessage("DbForeignKeyViolation", Description = "違反ForeignKey")]
        DbForeignKeyViolation = 2002,

        /// <summary>
        /// 該資料已停用
        /// </summary>
        [Description("該資料已停用")]
        [ResponseMessage("DataIsDisabled", Description = "該資料已停用")]
        DataIsDisabled = 2003,

        #endregion

        #region 身分驗證問題 3001-4000
        /// <summary>
        /// 無效的Token
        /// </summary>
        [Description("無效的Token")]
        [ResponseMessage("InvalidToken", Description = "無效的Token")]
        InvalidToken = 3001,

        /// <summary>
        /// Token已過期
        /// </summary>
        [Description("Token已過期")]
        [ResponseMessage("TokenOverDue", Description = "Token已過期")]
        TokenOverDue = 3002,

        /// <summary>
        /// Token為空
        /// </summary>
        [Description("Token為空")]
        [ResponseMessage("TokenIsNullOrEmpty", Description = "Token為空")]
        TokenIsNullOrEmpty = 3003,

        /// <summary>
        /// 沒有權限
        /// </summary>
        [Description("沒有權限")]
        [ResponseMessage("TokenForbidden", Description = "沒有權限")]
        TokenForbidden = 3004,
        #endregion

        #region Product (產品) 相關錯誤 10001-11000
        /// <summary>
        /// 不能新增組合產品
        /// </summary>
        [Description("不能新增組合產品")]
        [ResponseMessage("NotInsertCompositeProduct", Description = "不能新增組合產品")]
        NotInsertCompositeProduct = 10001,
        #endregion

        #region CompositeProduct (組合產品) 相關錯誤 11001-12000
        /// <summary>
        /// 不能新增非組合產品的資料
        /// </summary>
        [Description("不能新增非組合產品的資料")]
        [ResponseMessage("NotInsertProduct", Description = "不能新增非組合產品的資料")]
        NotInsertProduct = 11001,
        #endregion
    }
}
