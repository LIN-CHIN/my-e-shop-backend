using EShopAPI.Context;
using EShopAPI.Cores.ShopRoles.DTOs;
using EShopCores.Errors;
using EShopCores.Responses;
using Microsoft.EntityFrameworkCore;

namespace EShopAPI.Cores.ShopRoles.DAOs
{
    /// <summary>
    /// 商店角色的 DAO
    /// </summary>
    public class ShopRoleDao : IShopRoleDao
    {
        /// <summary>
        /// EShop context
        /// </summary>
        public readonly EShopContext _eShopContext;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="eShopContext"></param>
        public ShopRoleDao(EShopContext eShopContext) 
        {
            _eShopContext = eShopContext;
        }

        ///<inheritdoc/>
        public IQueryable<ShopRole> Get(QueryShopRoleDto queryDto)
        {
            IQueryable<ShopRole> shopRoles = _eShopContext.ShopRoles;

            if (!string.IsNullOrWhiteSpace(queryDto.Number)) 
            {
                shopRoles = shopRoles.Where(role => EF.Functions.Like(role.Number, $"%{queryDto.Number}%"));
            }

            if (!string.IsNullOrWhiteSpace(queryDto.Name))
            {
                shopRoles = shopRoles.Where(role => EF.Functions.Like(role.Name, $"%{queryDto.Name}%"));
            }

            if (queryDto.IsEnable != null) 
            {
                shopRoles = shopRoles.Where(role => role.IsEnable == queryDto.IsEnable);
            }

            return shopRoles;
        }

        ///<inheritdoc/>
        public async Task<ShopRole?> GetByIdAsync(long id)
        {
            return await _eShopContext.ShopRoles
                .Where(role => role.Id == id)
                .SingleOrDefaultAsync();
        }

        ///<inheritdoc/>
        public async Task<ShopRole> InsertAsync(ShopRole shopRole)
        {
            _eShopContext.Add(shopRole);
            await _eShopContext.SaveChangesAsync();
            return shopRole;
        }

        ///<inheritdoc/>
        public async Task UpdateAsync(ShopRole shopRole)
        {
            _eShopContext.Update(shopRole);
            await _eShopContext.SaveChangesAsync();
        }
    }
}
