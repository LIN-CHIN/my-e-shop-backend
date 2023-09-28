namespace EShopAPI.Cores.MapUserRoles.Services
{
    /// <summary>
    /// 使用者與角色關聯的 Service Interface
    /// </summary>
    public interface IMapUserRoleService
    {
        /// <summary>
        /// 根據使用者id取得使用者與角色的關聯清單
        /// </summary>
        /// <param name="userId">使用者id</param>
        /// <returns></returns>
        IQueryable<MapUserRole> GetByUserId(long userId);
    }
}
