using EShopCores.Enums;

namespace EShopAPI.Cores.ProductMasters.DTOs
{
    /// <summary>
    /// 查詢產品主檔用的DTO
    /// </summary>
    public class QueryProductMasterDto
    {
        /// <summary>
        /// 產品主檔代碼
        /// </summary>
        public string? Number { get; set; }

        /// <summary>
        /// 產品主檔名稱
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// 產品類型
        /// </summary>
        public ProductType? ProductType { get; set; }

        /// <summary>
        /// 是否啟用
        /// </summary>
        public bool? IsEnable { get; set; }
    }
}
