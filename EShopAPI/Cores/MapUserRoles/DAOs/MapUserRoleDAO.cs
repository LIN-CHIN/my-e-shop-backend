using EShopAPI.Context;

namespace EShopAPI.Cores.MapUserRoles.DAOs
{
    /// <summary>
    /// 使用者與角色關聯的 DAO
    /// </summary>
    public class MapUserRoleDAO : IMapUserRoleDAO
    {
        private readonly EShopContext _eShopContext;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="eShopContext"></param>
        public MapUserRoleDAO(EShopContext eShopContext) 
        {
            _eShopContext = eShopContext;
        }

        ///<inheritdoc/>
        public IQueryable<MapUserRole> GetByUserId(long userId)
        {
            return _eShopContext.MapUserRoles
                .Where(map => map.UserId == userId);
        }
    }
}
