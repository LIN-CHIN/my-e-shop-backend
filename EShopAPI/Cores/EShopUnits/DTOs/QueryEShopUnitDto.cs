namespace EShopAPI.Cores.EShopUnits.DTOs
{
    /// <summary>
    /// 查詢商店單位用的DTO
    /// </summary>
    public class QueryEShopUnitDto
    {
        /// <summary>
        /// 單位代碼
        /// </summary>
        public string? Number { get; set; } 

        /// <summary>
        /// 單位名稱
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// 是否啟用
        /// </summary>
        public bool? IsEnable { get; set; }

        /// <summary>
        /// 是否為系統預設
        /// </summary>
        public bool? IsSystemDefault { get; set; }
    }
}
