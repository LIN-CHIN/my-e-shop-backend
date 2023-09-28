using EShopAPI.Context;
using Microsoft.EntityFrameworkCore;

namespace EShopAPI.Cores.ShopRoles.DAOs
{
    /// <summary>
    /// 商店角色的 DAO
    /// </summary>
    public class ShopRoleDAO : IShopRoleDAO
    {
        /// <summary>
        /// EShop context
        /// </summary>
        public readonly EShopContext _eShopContext;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="eShopContext"></param>
        public ShopRoleDAO(EShopContext eShopContext) 
        {
            _eShopContext = eShopContext;
        }

        ///<inheritdoc/>
        public async Task<ShopRole?> GetById(long id)
        {
            return await _eShopContext.ShopRoles
                .Where(role => role.Id == id)
                .SingleOrDefaultAsync();
        }
    }
}
