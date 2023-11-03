namespace EShopAPI.Cores.CompositeProductItems.DTOs
{
    /// <summary>
    /// 查詢組合產品項目用的DTO
    /// </summary>
    public class QueryCompositeProductItemDto
    {
        /// <summary>
        /// 組合產品detail的id
        /// </summary>
        public long? CompositeProductId { get; set; }

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
        /// 是否總是特價
        /// </summary>
        public bool? IsAlwaysSale { get; set; }

        /// <summary>
        /// 特價起始日期
        /// </summary>
        public long? SaleStartDate { get; set; }

        /// <summary>
        /// 特價結束日期
        /// </summary>
        public long? SaleEndDate { get; set; }

    }
}
