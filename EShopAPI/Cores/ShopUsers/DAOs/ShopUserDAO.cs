using EShopAPI.Context;
using EShopAPI.Cores.ShopUsers.DTOs;
using Microsoft.EntityFrameworkCore;

namespace EShopAPI.Cores.ShopUsers.DAOs
{
    /// <summary>
    /// 使用者的 DAO
    /// </summary>
    public class ShopUserDao : IShopUserDao
    {
        /// <summary>
        /// eShop Context
        /// </summary>
        private readonly EShopContext _eShopContext;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="eShopContext"></param>
        public ShopUserDao(EShopContext eShopContext)
        {
            _eShopContext = eShopContext;
        }

        ///<inheritdoc/>
        public IQueryable<ShopUser> Get(QueryShopUserDto queryDto)
        {
            IQueryable<ShopUser> shopUsers = _eShopContext.ShopUsers;

            if (!string.IsNullOrWhiteSpace(queryDto.Number))
            {
                shopUsers = shopUsers.Where(user =>
                    EF.Functions.Like(user.Number, $"%{queryDto.Number}%"));
            }

            if (!string.IsNullOrWhiteSpace(queryDto.Name))
            {
                shopUsers = shopUsers.Where(user =>
                    EF.Functions.Like(user.Name, $"%{queryDto.Name}%"));
            }

            if (!string.IsNullOrWhiteSpace(queryDto.Email))
            {
                shopUsers = shopUsers.Where(user =>
                    EF.Functions.Like(user.Email!, $"%{queryDto.Email}%"));
            }

            return shopUsers;
        }

        ///<inheritdoc/>
        public async Task<ShopUser?> GetByIdAsync(long id)
        {
            return await _eShopContext.ShopUsers
                .Where(user => user.Id == id)
                .SingleOrDefaultAsync();
        }

        ///<inheritdoc/>
        public async Task<ShopUser?> GetByNumberAsync(string number)
        {
            return await _eShopContext.ShopUsers
                .Where(user => user.Number == number)
                .SingleOrDefaultAsync();
        }

        ///<inheritdoc/>
        public async Task<ShopUser> InsertAsync(ShopUser shopUser)
        {
            _eShopContext.ShopUsers.Add(shopUser);
            await _eShopContext.SaveChangesAsync();
            return shopUser;
        }

        ///<inheritdoc/>
        public async Task UpdaeAsync(ShopUser shopUser)
        {
            _eShopContext.ShopUsers.Update(shopUser);
            await _eShopContext.SaveChangesAsync();
        }
    }
}
