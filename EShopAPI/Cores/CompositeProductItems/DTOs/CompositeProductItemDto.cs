namespace EShopAPI.Cores.CompositeProductItems.DTOs
{
    /// <summary>
    /// 組合產品項目的查詢結果DTO
    /// </summary>
    public class CompositeProductItemDto : EShopObjectDto
    {
        /// <summary>
        /// 組合產品detail的id
        /// </summary>
        public long CompositeProductId { get; set; }

        /// <summary>
        /// 庫存id
        /// </summary>
        public long ShopInventoryId { get; set; }

        /// <summary>
        /// 單筆價格
        /// </summary>
        public int Price { get; set; }

        /// <summary>
        /// 數量
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// 是否總是特價
        /// </summary>
        public bool IsAlwaysSale { get; set; }

        /// <summary>
        /// 折扣數
        /// </summary>
        public double Discount { get; set; }

        /// <summary>
        /// 特價起始日期
        /// </summary>
        public long? SaleStartDate { get; set; }

        /// <summary>
        /// 特價結束日期
        /// </summary>
        public long? SaleEndDate { get; set; }

        /// <summary>
        /// 單位
        /// </summary>
        public long EshopUnitId { get; set; }
        
        /// <summary>
        /// 將實體解析為DTO
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static CompositeProductItemDto? Parse(CompositeProductItem? entity) 
        {
            if (entity == null) 
            {
                return null;
            }

            CompositeProductItemDto compositeProductItem = new CompositeProductItemDto
            {
                CompositeProductId = entity.CompositeProductId,
                ShopInventoryId = entity.ShopInventoryId,
                Price = entity.Price,
                Count = entity.Count,
                IsAlwaysSale = entity.IsAlwaysSale,
                Discount = entity.Discount,
                SaleStartDate = entity.SaleStartDate,
                SaleEndDate = entity.SaleEndDate,
                EshopUnitId = entity.EshopUnitId
            };

            compositeProductItem.ParseBaseObject(entity);

            return compositeProductItem;
        }
    }
}
