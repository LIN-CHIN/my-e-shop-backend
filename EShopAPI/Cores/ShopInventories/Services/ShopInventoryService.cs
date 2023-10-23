using EShopAPI.Common;
using EShopAPI.Cores.ShopInventories.DAOs;
using EShopAPI.Cores.ShopInventories.DTOs;

namespace EShopAPI.Cores.ShopInventories.Services
{
    /// <summary>
    /// 商店庫存 Service
    /// </summary>
    public class ShopInventoryService : IShopInventoryService
    {
        private readonly IShopInventoryDao _shopInventoryDao;
        private readonly LoginUserData _loginUserData;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="shopInventoryDao"></param>
        /// <param name="loginUserData"></param>
        public ShopInventoryService(IShopInventoryDao shopInventoryDao, LoginUserData loginUserData) 
        {
            _shopInventoryDao = shopInventoryDao;
            _loginUserData = loginUserData;
        }

        ///<inheritdoc/>
        public IQueryable<ShopInventory> Get(QueryShopInventoryDto queryDto)
        {
            throw new NotImplementedException();
        }

        ///<inheritdoc/>
        public async Task<ShopInventory?> GetByIdAsync(long id)
        {
            throw new NotImplementedException();
        }

        ///<inheritdoc/>
        public async Task<ShopInventory?> GetByNumberAsync(string number)
        {
            throw new NotImplementedException();
        }

        ///<inheritdoc/>
        public async Task<ShopInventory> InsertAsync(InsertShopInventoryDto insertDto)
        {
            throw new NotImplementedException();
        }

        ///<inheritdoc/>
        public async Task UpdateAsync(UpdateShopInventoryDto updateDto)
        {
            throw new NotImplementedException();
        }

        ///<inheritdoc/>
        public async Task DeleteAsync(long id)
        {
            throw new NotImplementedException();
        }

        ///<inheritdoc/>
        public async Task EnableAsync(long id, bool isEnable)
        {
            throw new NotImplementedException();
        }

        ///<inheritdoc/>
        public async Task<ShopInventory> ThrowExistByNumberAsync(string number)
        {
            throw new NotImplementedException();
        }

        ///<inheritdoc/>
        public async Task<ShopInventory> ThrowNotFindByIdAsync(long id)
        {
            throw new NotImplementedException();
        }
    }
}
