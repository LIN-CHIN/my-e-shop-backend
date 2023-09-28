namespace EShopAPI.Cores.ShopPermissions.Services
{
    /// <summary>
    /// 商店權限的 Service Interface
    /// </summary>
    public interface IShopPermissionService
    {
        /// <summary>
        /// 根據id取得權限實體
        /// </summary>
        /// <param name="id">權限id</param>
        /// <returns></returns>
        Task<ShopPermission?> GetById(long id);
    }
}
