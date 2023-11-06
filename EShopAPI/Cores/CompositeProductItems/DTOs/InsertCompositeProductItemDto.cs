using System.Text.Json;
using System.Text.Json.Serialization;
using EShopCores.Extensions;
using EShopCores.Json;

namespace EShopAPI.Cores.CompositeProductItems.DTOs
{
    /// <summary>
    /// 新增組合產品項目用的DTO
    /// </summary>
    public class InsertCompositeProductItemDto
    {
        /// <summary>
        /// 組合產品detail的id
        /// </summary>
        [JsonRequired]
        public long CompositeProductId { get; set; }

        /// <summary>
        /// 庫存id
        /// </summary>
        [JsonRequired]
        public long ShopInventoryId { get; set; }

        /// <summary>
        /// 單筆價格
        /// </summary>
        [JsonRequired]
        public int Price { get; set; }

        /// <summary>
        /// 數量
        /// </summary>
        [JsonRequired]
        public int Count { get; set; }

        /// <summary>
        /// 是否總是特價
        /// </summary>
        [JsonRequired]
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
        [JsonRequired]
        public long EshopUnitId { get; set; }

        /// <summary>
        /// 備註
        /// </summary>
        public string? Remarks { get; set; }

        /// <summary>
        /// 多國語系
        /// </summary>
        public IEnumerable<LanguageJson>? Languages { get; set; }

        /// <summary>
        /// 將DTO轉成實體
        /// </summary>
        /// <param name="userNumber">新增者帳號</param>
        /// <returns></returns>
        public CompositeProductItem ToEntity(string userNumber) 
        {
            return new CompositeProductItem
            {
                CompositeProductId = CompositeProductId,
                ShopInventoryId = ShopInventoryId,
                Price = Price,
                Count = Count,
                IsAlwaysSale = IsAlwaysSale,
                Discount = Discount,
                SaleStartDate = SaleStartDate,
                SaleEndDate = SaleEndDate,
                EshopUnitId = EshopUnitId,
                Remarks = Remarks,
                Language = JsonSerializer.SerializeToDocument(Languages),
                CreateUser = userNumber,
                CreateDate = DateTime.UtcNow.GetUnixTimeMillisecond()
            };
        }
    }
}
