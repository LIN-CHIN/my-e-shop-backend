namespace EShopAPI.Cores.ShopRoles.Services
{
    /// <summary>
    /// 商店角色 Service Interface
    /// </summary>
    public interface IShopRoleService
    {
        /// <summary>
        /// 根據id取得角色
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<ShopRole?> GetById(long id);
    }
}
