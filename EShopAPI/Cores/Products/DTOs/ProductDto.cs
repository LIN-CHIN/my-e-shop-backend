using System.Text.Json;

namespace EShopAPI.Cores.Products.DTOs
{
    /// <summary>
    /// 查詢產品回傳結果的DTO
    /// </summary>
    public class ProductDto : EShopObjectDto
    {
        /// <summary>
        /// 庫存id
        /// </summary>
        public long ShopInventoryId { get; set; }

        /// <summary>
        /// 價格
        /// </summary>
        public int Price { get; set; }

        /// <summary>
        /// 商店單位id
        /// </summary>
        public long EShopUnitId { get; set; }

        /// <summary>
        /// 是否總是特價
        /// </summary>
        public bool IsAlwaysSale { get; set; }

        /// <summary>
        /// 折扣數
        /// </summary>
        public double? Discount { get; set; }

        /// <summary>
        /// 特價起始日期
        /// </summary>
        public long? SaleStartDate { get; set; }

        /// <summary>
        /// 特價結束日期
        /// </summary>
        public long? SaleEndDate { get; set; }

        /// <summary>
        /// 是否可以使用優惠券
        /// </summary>
        public bool IsUseCoupon { get; set; }

        /// <summary>
        /// 變種屬性
        /// </summary>
        /// <remarks>
        /// 這個產品的變種屬性分別對應的值?
        /// </remarks>
        public JsonDocument? VariantAttribute { get; set; }

        /// <summary>
        /// 將實體解析DTO
        /// </summary>
        /// <param name="product">產品實體</param>
        /// <returns></returns>
        public static ProductDto? Parse(Product? product) 
        {
            if (product == null) 
            {
                return null;
            }

            ProductDto productDto = new ProductDto
            {
                ShopInventoryId = product.ShopInventoryId,
                Price = product.Price,
                EShopUnitId = product.EShopUnitId,
                IsAlwaysSale = product.IsAlwaysSale,
                Discount = product.Discount,
                SaleStartDate = product.SaleStartDate,
                SaleEndDate = product.SaleEndDate,
                IsUseCoupon = product.IsUseCoupon,
                VariantAttribute = product.VariantAttribute,
            };

            productDto.ParseBaseObject(product);

            return productDto;
        }
    }
}
