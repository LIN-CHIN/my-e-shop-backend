using EShopAPI.Context;
using Microsoft.EntityFrameworkCore;

namespace EShopAPI.Cores.ShopUsers.DAOs
{
    /// <summary>
    /// 使用者的 DAO
    /// </summary>
    public class ShopUserDAO : IShopUserDAO
    {
        /// <summary>
        /// eShop Context
        /// </summary>
        private readonly EShopContext _eShopContext;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="eShopContext"></param>
        public ShopUserDAO(EShopContext eShopContext) 
        {
            _eShopContext = eShopContext;
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

       
    }
}
