using EShopAPI.Context;
using EShopAPI.Cores.ShopUsers.DTOs;
using EShopCores.Errors;
using EShopCores.Responses;
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
        public IQueryable<ShopUser> Get(QueryShopUserDto queryDTO)
        {
            IQueryable<ShopUser> shopUsers = _eShopContext.ShopUsers;

            if (!string.IsNullOrWhiteSpace(queryDTO.Number))
            {
                shopUsers = shopUsers.Where(user =>
                    EF.Functions.Like(user.Number, $"%{queryDTO.Number}%"));
            }

            if (!string.IsNullOrWhiteSpace(queryDTO.Name))
            {
                shopUsers = shopUsers.Where(user =>
                    EF.Functions.Like(user.Name, $"%{queryDTO.Name}%"));
            }

            if (!string.IsNullOrWhiteSpace(queryDTO.Email))
            {
                shopUsers = shopUsers.Where(user =>
                    EF.Functions.Like(user.Email!, $"%{queryDTO.Email}%"));
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
        public async Task ThrowNotFindByNumberAsync(string number)
        {
            ShopUser? shopUser = await _eShopContext.ShopUsers
                .Where(user => user.Number == number)
                .SingleOrDefaultAsync();

            if (shopUser == null)
            {
                throw new EShopException(ResponseCodeType.DuplicateData, "帳號已存在");
            }
        }

        ///<inheritdoc/>
        public async Task<ShopUser> ThrowNotFindByIdAsync(long id)
        {
            ShopUser? shopUser = await _eShopContext.ShopUsers
                .Where(user => user.Id == id)
                .SingleOrDefaultAsync();

            if (shopUser == null)
            {
                throw new EShopException(
                    ResponseCodeType.RequestParameterError,
                    $"找不到使用者id :{id}");
            }

            return shopUser;
        }

        ///<inheritdoc/>
        public async Task<ShopUser> InsertAsync(ShopUser shopUser)
        {
            _eShopContext.ShopUsers.Add(shopUser);
            await _eShopContext.SaveChangesAsync();
            return shopUser;
        }

        ///<inheritdoc/>
        public async Task UpdateAsync(ShopUser shopUser)
        {
            _eShopContext.ShopUsers.Update(shopUser);
            await _eShopContext.SaveChangesAsync();
        }
    }
}
