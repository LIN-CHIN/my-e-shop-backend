using EShopCores.Extensions;
using EShopCores.Json;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace EShopAPI.Cores.CompositeProducts.DTOs
{
    /// <summary>
    /// 新增組合產品用的DTO
    /// </summary>
    public class InsertCompositeProductDto
    {
        /// <summary>
        /// 庫存id
        /// </summary>
        [JsonRequired]
        public long ShopInventoryId { get; set; }

        /// <summary>
        /// 商店單位id
        /// </summary>
        [JsonRequired]
        public long EShopUnitId { get; set; }

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
        /// 轉成實體
        /// </summary>
        /// <param name="userNumber">新增者的帳號</param>
        /// <returns></returns>
        public CompositeProduct ToEntity(string userNumber) 
        {
            return new CompositeProduct
            {
                ShopInventoryId = ShopInventoryId,
                EShopUnitId = EShopUnitId,
                IsUseCoupon = IsUseCoupon,
                Remarks = Remarks,
                Language = JsonSerializer.SerializeToDocument(Languages),
                CreateUser = userNumber,
                CreateDate = DateTime.UtcNow.GetUnixTimeMillisecond()
            };
        }
    }
}
