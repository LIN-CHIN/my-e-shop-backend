namespace EShopAPI.Cores.Products.DTOs
{
    /// <summary>
    /// 查詢產品用的搜尋條件DTO
    /// </summary>
    public class QueryProductDto
    {
        /// <summary>
        /// 庫存id
        /// </summary>
        public long? ShopInventoryId { get; set; }
        
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
