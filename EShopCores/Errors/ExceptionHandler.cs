using EShopCores.Responses;

namespace EShopCores.Errors
{
    /// <summary>
    /// 負責錯誤處理的class
    /// </summary>
    public class ExceptionHandler : Exception
    {
        /// <summary>
        /// Response代碼
        /// </summary>
        public ResponseCodeType Code { get; set; }

        /// <summary>
		/// 回傳內容，錯誤訊息補充
		/// </summary>
		public string Content { get; set; } = "";

        /// <summary>
        /// 錯誤訊息
        /// </summary>
        public string Message { get; set; } = "";

        /// <summary>
		/// exception內容
		/// </summary>
		public string Description { get; set; } = "";

        public ExceptionHandler()
            : base()
        {
        }

        public ExceptionHandler(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="code">錯誤代碼</param>
        /// <param name="content">錯誤內容訊息補充</param>
        public ExceptionHandler(ResponseCodeType code, string content)
            : base(code.GetMessage())
        {
            Code = code;
            Message = code.GetMessage();
            Description = code.GetDescription();
            Content = content;
        }
    }
}
