using EShopCores.Enums;
using System.Text.Json;

namespace EShopAPI.Cores.ShopInventories.DTOs
{
    /// <summary>
    /// 查詢商店庫存用的DTO (回傳結果)
    /// </summary>
    public class ShopInventoryDto : EShopObjectDto
    {
        /// <summary>
        /// 商品代碼
        /// </summary>
        public string Number { get; set; } = null!;

        /// <summary>
        /// 商品名稱
        /// </summary>
        public string Name { get; set; } = null!;

        /// <summary>
        /// 商品庫存數量
        /// </summary>
        public int InventoryQuantity { get; set; }

        /// <summary>
        /// 商品庫存警告數
        /// </summary>
        public int InventoryAlert { get; set; }

        /// <summary>
        /// 供應商
        /// </summary>
        public string? Supplier { get; set; }

        /// <summary>
        /// 品牌
        /// </summary>
        public string? Brand { get; set; }

        /// <summary>
        /// 產品類型
        /// </summary>
        public ProductType ProductType { get; set; }

        /// <summary>
        /// 是否為組合產品
        /// </summary>
        public bool IsComposite { get; set; }

        /// <summary>
        /// 是否只能讓組合產品使用
        /// </summary>
        public bool IsCompositeOnly { get; set; }

        /// <summary>
        /// 是否啟用
        /// </summary>
        public bool IsEnable { get; set; }

        /// <summary>
        /// 變種屬性清單
        /// </summary>
        /// <remarks>
        /// 這個產品有哪個變種屬性? 值是是什麼
        /// ex: color: red, size: s
        /// </remarks>
        public JsonDocument? VariantAttribute { get; set; }

        /// <summary>
        /// 將實體解析成ShopInventoryDto
        /// </summary>
        /// <param name="entity">實體</param>
        /// <returns></returns>
        public ShopInventoryDto? Parse(ShopInventory? entity) 
        {
            if (entity == null) 
            {
                return null;
            }

            ShopInventoryDto shopInventoryDto = new ShopInventoryDto()
            {
                Number = entity.Number,
                Name = entity.Name,
                InventoryQuantity = entity.InventoryQuantity,
                InventoryAlert = entity.InventoryAlert,
                Supplier = entity.Supplier,
                Brand = entity.Brand,
                ProductType = entity.ProductType,
                IsComposite = entity.IsComposite,
                IsCompositeOnly = entity.IsCompositeOnly,
                IsEnable = entity.IsEnable,
                VariantAttribute = entity.VariantAttribute,
            };

            shopInventoryDto.ParseBaseObject(entity);
            return shopInventoryDto;
        }
    }
}
