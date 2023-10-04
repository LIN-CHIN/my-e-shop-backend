namespace EShopAPI.Cores.MapUserRoles.DAOs
{
    /// <summary>
    /// 使用者與角色關聯的 DAO Interface
    /// </summary>
    public interface IMapUserRoleDao
    {
        /// <summary>
        /// 根據使用者id取得使用者與角色的關聯清單
        /// </summary>
        /// <param name="userId">使用者id</param>
        /// <returns></returns>
        IQueryable<MapUserRole> GetByUserId(long userId);
    }
}
