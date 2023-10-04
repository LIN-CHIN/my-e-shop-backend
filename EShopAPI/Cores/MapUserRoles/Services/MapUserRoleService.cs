using EShopAPI.Cores.MapUserRoles.DAOs;

namespace EShopAPI.Cores.MapUserRoles.Services
{
    /// <summary>
    /// 使用者與角色關聯的 Service
    /// </summary>
    public class MapUserRoleService : IMapUserRoleService
    {
        private readonly IMapUserRoleDao _mapUserRoleDao;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="mapUserRoleDao"></param>
        public MapUserRoleService(IMapUserRoleDao mapUserRoleDao) 
        {
            _mapUserRoleDao = mapUserRoleDao;
        }

        ///<inheritdoc/>
        public IQueryable<MapUserRole> GetByUserId(long userId)
        {
            return _mapUserRoleDao.GetByUserId(userId);
        }
    }
}
