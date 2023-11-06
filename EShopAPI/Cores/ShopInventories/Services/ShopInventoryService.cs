using EShopAPI.Common;
using EShopAPI.Cores.ShopInventories.DAOs;
using EShopAPI.Cores.ShopInventories.DTOs;
using EShopCores.Errors;
using EShopCores.Extensions;
using EShopCores.Responses;

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
            return _shopInventoryDao.Get(queryDto);
        }

        ///<inheritdoc/>
        public async Task<ShopInventory?> GetByIdAsync(long id)
        {
            return await _shopInventoryDao.GetByIdAsync(id);
        }

        ///<inheritdoc/>
        public async Task<ShopInventory?> GetByNumberAsync(string number)
        {
            return await _shopInventoryDao.GetByNumberAsync(number);
        }

        ///<inheritdoc/>
        public async Task<ShopInventory> InsertAsync(InsertShopInventoryDto insertDto)
        {
            await ThrowExistByNumberAsync(insertDto.Number);
            return await _shopInventoryDao.InsertAsync(insertDto
                    .ToEntity(_loginUserData.UserNumber));
        }

        ///<inheritdoc/>
        public async Task UpdateAsync(UpdateShopInventoryDto updateDto)
        {
            ShopInventory shopInventory = await ThrowNotFindByIdAsync(updateDto.Id);
            await _shopInventoryDao.UpdateAsync(updateDto
                .SetEntity(shopInventory, _loginUserData.UserNumber));
        }

        ///<inheritdoc/>
        public async Task EnableAsync(long id, bool isEnable)
        {
            ShopInventory shopInventory = await ThrowNotFindByIdAsync(id);
            shopInventory.IsEnable = isEnable;
            shopInventory.UpdateDate = DateTime.UtcNow.GetUnixTimeMillisecond();
            shopInventory.UpdateUser = _loginUserData.UserNumber;
            await _shopInventoryDao.UpdateAsync(shopInventory);
        }

        ///<inheritdoc/>
        public async Task ThrowExistByNumberAsync(string number)
        {
            ShopInventory? shopInventory = await _shopInventoryDao.GetByNumberAsync(number);
            if (shopInventory != null) 
            {
                throw new EShopException(ResponseCodeType.DuplicateData, "產品代碼已存在");
            }
        }

        ///<inheritdoc/>
        public async Task<ShopInventory> ThrowNotFindByIdAsync(long id)
        {
            ShopInventory? shopInventory = await _shopInventoryDao.GetByIdAsync(id);
            if (shopInventory == null)
            {
                throw new EShopException(ResponseCodeType.RequestParameterError, $"商店庫存id:'{id}'不存在");
            }

            return shopInventory;
        }

        ///<inheritdoc/>
        public async Task<bool> IsProductEnableAsync(long id)
        {
            ShopInventory shopInventory = await ThrowNotFindByIdAsync(id);
            return shopInventory.IsEnable;
        }
    }
}
