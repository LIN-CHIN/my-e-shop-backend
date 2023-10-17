using System.ComponentModel;

namespace EShopAPI.Common.Enums
{
    /// <summary>
    /// Http method type
    /// </summary>
    public enum HttpMethodType
    {
        /// <summary>
        /// 查詢
        /// </summary>
        [Description("查詢")]
        GET = 1,

        /// <summary>
        /// 新增
        /// </summary>
        [Description("新增")]
        POST = 2,

        /// <summary>
        /// 修改
        /// </summary>
        [Description("修改")]
        PUT = 3,

        /// <summary>
        /// 部分修改
        /// </summary>
        [Description("部分修改")]
        PATCH = 4,

        /// <summary>
        /// 刪除
        /// </summary>
        [Description("刪除")]
        DELETE = 5
    }
}
