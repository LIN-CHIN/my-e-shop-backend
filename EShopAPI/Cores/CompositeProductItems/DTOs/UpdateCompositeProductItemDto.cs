using EShopAPI.Cores.EShopUnits;
using EShopCores.Extensions;
using EShopCores.Json;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace EShopAPI.Cores.CompositeProductItems.DTOs
{
    /// <summary>
    /// 編輯組合產品項目用的DTO
    /// </summary>
    public class UpdateCompositeProductItemDto
    {
        /// <summary>
        /// 組合產品項目的id
        /// </summary>
        [JsonRequired]
        public long Id { get; set; }

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
        /// 將傳入的實體修改後回傳
        /// </summary>
        /// <param name="compositeProductItem">要被修改的實體</param>
        /// <param name="userNumber">編輯者的帳號</param>
        /// <returns></returns>
        public CompositeProductItem SetEntity(CompositeProductItem compositeProductItem, string userNumber) 
        {
            compositeProductItem.Price = Price;
            compositeProductItem.Count = Count;
            compositeProductItem.IsAlwaysSale = IsAlwaysSale;
            compositeProductItem.Discount = Discount;
            compositeProductItem.SaleStartDate = SaleStartDate;
            compositeProductItem.SaleEndDate = SaleEndDate;
            compositeProductItem.EshopUnitId = EshopUnitId;
            compositeProductItem.Remarks = Remarks;
            compositeProductItem.Language = JsonSerializer.SerializeToDocument(Languages);
            compositeProductItem.UpdateUser = userNumber;
            compositeProductItem.UpdateDate = DateTime.UtcNow.GetUnixTimeMillisecond();

            return compositeProductItem;
        }
    }
}
