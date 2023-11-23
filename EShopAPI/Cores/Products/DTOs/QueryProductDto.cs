namespace EShopAPI.Cores.Products.DTOs
{
    /// <summary>
    /// 查詢產品用的搜尋條件DTO
    /// </summary>
    public class QueryProductDto
    {
        /// <summary>
        /// 產品代碼 (庫存table中的number)
        /// </summary>
        public string? ProductNumber { get; set; }

        /// <summary>
        /// 產品名稱 (庫存table中的name)
        /// </summary>
        public string? ProductName { get; set; }

        /// <summary>
        /// 價格區間(起)
        /// </summary>
        public int? PriceScopeStart { get; set; }

        /// <summary>
        /// 價格區間(迄)
        /// </summary>
        public int? PriceScopeEnd { get; set; }

        /// <summary>
        /// 特價起始日期
        /// </summary>
        public long? SaleStartDate { get; set; }

        /// <summary>
        /// 特價結束日期
        /// </summary>
        public long? SaleEndDate { get; set; }

        /// <summary>
        /// 是否啟用
        /// </summary>
        public bool? IsEnable { get; set; }
    }
}
