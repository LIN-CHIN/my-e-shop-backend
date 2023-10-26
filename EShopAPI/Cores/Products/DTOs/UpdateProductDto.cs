using EShopCores.Extensions;
using EShopCores.Json;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace EShopAPI.Cores.Products.DTOs
{
    /// <summary>
    /// 編輯產品用的DTO
    /// </summary>
    public class UpdateProductDto
    {
        /// <summary>
        /// 要編輯的產品id
        /// </summary>
        [JsonRequired]
        public long Id { get; set; }

        /// <summary>
        /// 價格
        /// </summary>
        [JsonRequired]
        public int Price { get; set; }

        /// <summary>
        /// 商店單位id
        /// </summary>
        [JsonRequired]
        public long EShopUnitId { get; set; }

        /// <summary>
        /// 是否總是特價
        /// </summary>
        [JsonRequired]
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
        [JsonRequired]
        public bool IsUseCoupon { get; set; }

        /// <summary>
        /// 備註
        /// </summary>
        public string? Remarks { get; set; }

        /// <summary>
        /// 多國語系
        /// </summary>
        public IEnumerable<LanguageJson>? Languages { get; set; }

        /// <summary>
        /// 用DTO設定實體並回傳
        /// </summary>
        /// <param name="product">要被修改的實體</param>
        /// <param name="userNumber">編輯者的帳號</param>
        /// <returns></returns>
        public Product SetEntity(Product product, string userNumber) 
        {
            product.Price = Price;
            product.EShopUnitId = EShopUnitId;
            product.IsAlwaysSale = IsAlwaysSale;
            product.Discount = Discount;
            product.SaleStartDate = SaleStartDate;
            product.SaleEndDate = SaleEndDate;
            product.IsUseCoupon = IsUseCoupon;
            product.Remarks = Remarks;
            product.Language = JsonSerializer.SerializeToDocument(Languages);
            product.UpdateUser = userNumber;
            product.UpdateDate = DateTime.UtcNow.GetUnixTimeMillisecond();

            return product;
        }
    }
}
