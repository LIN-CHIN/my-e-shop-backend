using EShopAPI.Cores.MapUserRoles.DAOs;

namespace EShopAPI.Cores.MapUserRoles.Services
{
    /// <summary>
    /// 使用者與角色關聯的 Service
    /// </summary>
    public class MapUserRoleService : IMapUserRoleService
    {
        private readonly IMapUserRoleDAO _mapUserRoleDAO;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="mapUserRoleDAO"></param>
        public MapUserRoleService(IMapUserRoleDAO mapUserRoleDAO) 
        {
            _mapUserRoleDAO = mapUserRoleDAO;
        }

        ///<inheritdoc/>
        public IQueryable<MapUserRole> GetByUserId(long userId)
        {
            return _mapUserRoleDAO.GetByUserId(userId);
        }
    }
}
