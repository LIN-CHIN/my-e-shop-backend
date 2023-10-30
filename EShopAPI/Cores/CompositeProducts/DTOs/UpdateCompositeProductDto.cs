using EShopAPI.Cores.EShopUnits;
using EShopCores.Extensions;
using EShopCores.Json;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace EShopAPI.Cores.CompositeProducts.DTOs
{
    /// <summary>
    /// 編輯組合產品用的DTO
    /// </summary>
    public class UpdateCompositeProductDto
    {
        /// <summary>
        /// 組合產品的id
        /// </summary>
        [JsonRequired]
        public long Id { get; set; }

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
        /// 用DTO設定實體的值
        /// </summary>
        /// <param name="compositeProduct">要編輯的組合產品實體</param>
        /// <param name="userNumber">編輯者帳號</param>
        /// <returns></returns>
        public CompositeProduct SetEntity(CompositeProduct compositeProduct, string userNumber) 
        {
            compositeProduct.EShopUnitId = EShopUnitId;
            compositeProduct.IsUseCoupon = IsUseCoupon;
            compositeProduct.Remarks = Remarks;
            compositeProduct.Language = JsonSerializer.SerializeToDocument(Languages);
            compositeProduct.UpdateUser = userNumber;
            compositeProduct.UpdateDate = DateTime.UtcNow.GetUnixTimeMillisecond();

            return compositeProduct;
        }
    }
}
