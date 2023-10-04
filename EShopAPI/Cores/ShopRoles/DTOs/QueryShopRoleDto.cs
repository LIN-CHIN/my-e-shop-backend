namespace EShopAPI.Cores.ShopRoles.DTOs
{
    /// <summary>
    /// 查詢角色用的DTO
    /// </summary>
    public class QueryShopRoleDto
    {
        /// <summary>
        /// 角色代碼
        /// </summary>
        public string? Number { get; set; }

        /// <summary>
        /// 角色名稱
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// 是否啟用
        /// </summary>
        public bool? IsEnable { get; set; }
    }
}
