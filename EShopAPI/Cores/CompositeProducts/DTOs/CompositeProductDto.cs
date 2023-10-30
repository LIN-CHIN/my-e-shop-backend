using EShopAPI.Cores.EShopUnits;
using EShopAPI.Cores.ShopInventories;

namespace EShopAPI.Cores.CompositeProducts.DTOs
{
    /// <summary>
    /// 回傳查詢結果用的組合產品DTO
    /// </summary>
    public class CompositeProductDto : EShopObjectDto
    {
        /// <summary>
        /// 庫存id
        /// </summary>
        public long ShopInventoryId { get; set; }

        /// <summary>
        /// 商店單位id
        /// </summary>
        public long EShopUnitId { get; set; }

        /// <summary>
        /// 是否可以使用優惠券
        /// </summary>
        public bool IsUseCoupon { get; set; }

        /// <summary>
        /// 將實體轉成DTO
        /// </summary>
        /// <param name="compositeProduct">組合產品的實體</param>
        /// <returns></returns>
        public static CompositeProductDto? Parse(CompositeProduct? compositeProduct)
        {
            if (compositeProduct == null)
            {
                return null;
            }

            CompositeProductDto compositeProductDto = new CompositeProductDto
            {
                ShopInventoryId = compositeProduct.ShopInventoryId,
                EShopUnitId = compositeProduct.EShopUnitId,
                IsUseCoupon = compositeProduct.IsUseCoupon
            };

            compositeProductDto.ParseBaseObject(compositeProduct);
            return compositeProductDto;
        }
    }
}
