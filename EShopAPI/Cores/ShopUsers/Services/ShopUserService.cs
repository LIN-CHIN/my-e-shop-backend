using EShopAPI.Cores.ShopUsers.DAOs;
using EShopAPI.Cores.ShopUsers.DTOs;
using EShopCores.Errors;
using EShopCores.Responses;

namespace EShopAPI.Cores.ShopUsers.Services
{
    /// <summary>
    /// 使用者的 Service
    /// </summary>
    public class ShopUserService : IShopUserService
    {
        private readonly IShopUserDao _shopUserDAO; 

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="shopUserDAO"></param>
        public ShopUserService(IShopUserDao shopUserDAO) 
        {
            _shopUserDAO = shopUserDAO;
        }

        ///<inheritdoc/>
        public IQueryable<ShopUser> Get(QueryShopUserDto queryDTO)
        {
            return _shopUserDAO.Get(queryDTO);
        }

        ///<inheritdoc/>
        public Task<ShopUser?> GetByIdAsync(long id)
        {
            return _shopUserDAO.GetByIdAsync(id);
        }

        ///<inheritdoc/>
        public async Task<ShopUser?> GetByNumberAsync(string number)
        {
            return await _shopUserDAO.GetByNumberAsync(number);
        }

        ///<inheritdoc/>
        public async Task<ShopUser> InsertAsync(InsertShopUserDto insertDTO)
        {
            await _shopUserDAO.ThrowNotFindByNumberAsync(insertDTO.Number);
            return await _shopUserDAO.InsertAsync(insertDTO.ToEntity());
        }

        ///<inheritdoc/>
        public async Task UpdateAsync(UpdateShopUserDto updateDTO)
        {
            ShopUser? shopUser = await _shopUserDAO.ThrowNotFindByIdAsync(updateDTO.Id);
            await _shopUserDAO.UpdateAsync(updateDTO.SetEntity(shopUser));
        }

        ///<inheritdoc/>
        public async Task EnableAsync(long id, bool isEnable)
        {
            ShopUser? shopUser = await _shopUserDAO.ThrowNotFindByIdAsync(id);
            shopUser.IsEnable = isEnable;
            await _shopUserDAO.UpdateAsync(shopUser);
        }
    }
}
