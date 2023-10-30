namespace EShopAPI.Cores.CompositeProducts.DTOs
{
    /// <summary>
    /// 查詢組合產品用的搜尋條件DTO
    /// </summary>
    public class QueryCompositeProductDto
    {
        /// <summary>
        /// 庫存id
        /// </summary>
        public long? ShopInventoryId { get; set; }

        /// <summary>
        /// 商店單位id
        /// </summary>
        public long? EShopUnitId { get; set; }

        /// <summary>
        /// 是否可以使用優惠券
        /// </summary>
        public bool? IsUseCoupon { get; set; }
    }
}
