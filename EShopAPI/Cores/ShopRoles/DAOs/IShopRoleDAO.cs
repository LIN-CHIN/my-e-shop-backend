namespace EShopAPI.Cores.ShopRoles.DAOs
{
    /// <summary>
    /// 商店角色的 DAO Interface
    /// </summary>
    public interface IShopRoleDao
    {
        /// <summary>
        /// 根據id取得角色
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<ShopRole?> GetById(long id);
    }
}
