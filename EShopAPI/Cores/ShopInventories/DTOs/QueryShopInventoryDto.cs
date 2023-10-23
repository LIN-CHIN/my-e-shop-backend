using EShopAPI.Validations;
using EShopCores.Enums;

namespace EShopAPI.Cores.ShopInventories.DTOs
{
    /// <summary>
    /// 查詢商店庫存用的DTO
    /// </summary>
    public class QueryShopInventoryDto
    {
        /// <summary>
        /// 商品代碼
        /// </summary>
        public string? Number { get; set; }

        /// <summary>
        /// 商品名稱
        /// </summary>
        public string? Name { get; set; } 

        /// <summary>
        /// 商品庫存數量
        /// </summary>
        public int? InventoryQuantity { get; set; }

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
        public ProductType? ProductType { get; set; }

        /// <summary>
        /// 是否為組合產品
        /// </summary>
        public bool? IsComposite { get; set; }

        /// <summary>
        /// 是否只能讓組合產品使用
        /// </summary>
        public bool? IsCompositeOnly { get; set; }

        /// <summary>
        /// 是否啟用
        /// </summary>
        public bool? IsEnable { get; set; }

    }
}
