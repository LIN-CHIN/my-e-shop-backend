using EShopCores.Extensions;
using EShopCores.Json;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace EShopAPI.Cores.Products.DTOs
{
    /// <summary>
    /// 新增產品用的DTO
    /// </summary>
    public class InsertProductDto
    {
        /// <summary>
        /// 庫存id
        /// </summary>
        [JsonRequired]
        public long ShopInventoryId { get; set; }

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
        /// 該產品的變種屬性
        /// </summary>
        /// <remarks>
        /// 這個產品的變種屬性分別對應的值?
        /// </remarks>
        public IEnumerable<VariantAttributeJson>? VariantAttributes { get; set; }

        /// <summary>
        /// 備註
        /// </summary>
        public string? Remarks { get; set; }

        /// <summary>
        /// 多國語系
        /// </summary>
        public IEnumerable<LanguageJson>? Languages { get; set; }

        /// <summary>
        /// 轉成實體
        /// </summary>
        /// <param name="userNumber">新增者的帳號</param>
        /// <returns></returns>
        public Product ToEntity(string userNumber) 
        {
            return new Product
            {
                ShopInventoryId = ShopInventoryId,
                Price = Price,
                EShopUnitId = EShopUnitId,
                IsAlwaysSale = IsAlwaysSale,
                Discount = Discount,
                SaleStartDate = SaleStartDate,
                SaleEndDate = SaleEndDate,
                IsUseCoupon = IsUseCoupon,
                VariantAttribute = JsonSerializer.SerializeToDocument(VariantAttributes),
                Remarks = Remarks,
                Language = JsonSerializer.SerializeToDocument(Languages),
                CreateUser = userNumber,
                CreateDate = DateTime.UtcNow.GetUnixTimeMillisecond()
            };
        }
    }
}
