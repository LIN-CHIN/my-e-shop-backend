using EShopAPI.Cores.ShopUsers.DTOs;
using EShopAPI.Cores.ShopUsers;
using EShopCores.Enums;
using System.Text.Json;

namespace EShopAPI.Cores.ProductMasters.DTOs
{
    /// <summary>
    /// 產品主檔回傳用的DTO
    /// </summary>
    public class ProductMasterDto : EShopObjectDto
    {
        /// <summary>
        /// 產品主編號
        /// </summary>
        public string Number { get; set; } = null!;

        /// <summary>
        /// 產品主名稱
        /// </summary>
        public string Name { get; set; } = null!;

        /// <summary>
        /// 產品類型
        /// </summary>
        public ProductType ProductType { get; set; }

        /// <summary>
        /// 是否啟用
        /// </summary>
        public bool IsEnable { get; set; }

        /// <summary>
        /// 變種屬性
        /// </summary>
        /// <remarks>
        /// 這個產品變種屬性有哪一些值?
        /// ex: color:[red, blue], size[S,M]
        /// </remarks>
        public JsonDocument? VariantAttribute { get; set; }

        /// <summary>
        /// 將實體解析成ProductMasterDto
        /// </summary>
        /// <param name="productMaster"></param>
        /// <returns></returns>
        public static ProductMasterDto? Parse(ProductMaster? productMaster)
        {
            if (productMaster == null)
            {
                return null;
            }

            ProductMasterDto productMasterDto = new ProductMasterDto
            {
                Number = productMaster.Number,
                Name = productMaster.Name,
                ProductType = productMaster.ProductType,
                IsEnable = productMaster.IsEnable,
                VariantAttribute = productMaster.VariantAttribute
            };

            productMasterDto.ParseBaseObject(productMaster);
            return productMasterDto;
        }
    }
}
