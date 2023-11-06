using EShopAPI.Common;
using EShopAPI.Cores.CompositeProductItems.DAOs;
using EShopAPI.Cores.CompositeProductItems.DTOs;
using EShopAPI.Cores.ShopInventories.Services;
using EShopCores.Errors;
using EShopCores.Responses;

namespace EShopAPI.Cores.CompositeProductItems.Services
{
    /// <summary>
    /// 組合產品項目的 Service
    /// </summary>
    public class CompositeProductItemService : ICompositeProductItemService
    {
        private readonly ICompositeProductItemDao _compositeProductItemDao;
        private readonly IShopInventoryService _shopInventoryService;
        private readonly LoginUserData _loginUserData;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="compositeProductItemDao"></param>
        /// <param name="shopInventoryService"></param>
        /// <param name="loginUserData"></param>
        public CompositeProductItemService(ICompositeProductItemDao compositeProductItemDao,
            IShopInventoryService shopInventoryService,
            LoginUserData loginUserData) 
        {
            _compositeProductItemDao = compositeProductItemDao;
            _shopInventoryService = shopInventoryService;
            _loginUserData = loginUserData;
        }

        ///<inheritdoc/>
        public IQueryable<CompositeProductItem> Get(QueryCompositeProductItemDto queryDto)
        {
            return _compositeProductItemDao.Get(queryDto);
        }

        ///<inheritdoc/>
        public IQueryable<CompositeProductItem> GetByCompositeProductId(long compositeProductId)
        {
            return _compositeProductItemDao.GetByCompositeProductId(compositeProductId);
        }

        ///<inheritdoc/>
        public async Task<CompositeProductItem?> GetByIdAsync(long id)
        {
            return await _compositeProductItemDao.GetByIdAsync(id);
        }

        ///<inheritdoc/>
        public async Task<CompositeProductItem> InsertAsync(InsertCompositeProductItemDto insertDto)
        {
            bool isEnable = await _shopInventoryService.IsProductEnableAsync(insertDto.ShopInventoryId);

            if (!isEnable) 
            {
                throw new EShopException(ResponseCodeType.DataIsDisabled,
                    $"該產品已被停用， ShopInventoryId: {insertDto.ShopInventoryId}");
            }

            //根據組合產品id 取出全部的項目
            IQueryable<CompositeProductItem> compositeProductItems =
                _compositeProductItemDao.GetByCompositeProductId(insertDto.CompositeProductId);

            if (compositeProductItems.Any(cpi => cpi.ShopInventoryId == insertDto.ShopInventoryId))
            {
                throw new EShopException(ResponseCodeType.DuplicateData,
                    $"該組合產品已經有相同的項目，商店庫存id : {insertDto.ShopInventoryId}");
            }

            return await _compositeProductItemDao.InsertAsync(
                insertDto.ToEntity(_loginUserData.UserNumber));
        }

        ///<inheritdoc/>
        public async Task UpdateAsync(UpdateCompositeProductItemDto updateDto)
        {
            CompositeProductItem compositeProductItem = await ThrowNotFindByIdAsync(updateDto.Id);
            await _compositeProductItemDao.UpdateAsync(updateDto
                        .SetEntity(compositeProductItem, _loginUserData.UserNumber));
        }

        ///<inheritdoc/>
        public async Task DeleteAsync(long id)
        {
            CompositeProductItem compositeProductItem = await ThrowNotFindByIdAsync(id);
            await _compositeProductItemDao.DeleteAsync(compositeProductItem);
        }

        ///<inheritdoc/>
        public async Task<CompositeProductItem> ThrowNotFindByIdAsync(long id)
        {
            CompositeProductItem? compositeProductItem =
                await _compositeProductItemDao.GetByIdAsync(id);

            if (compositeProductItem == null) 
            {
                throw new EShopException(ResponseCodeType.RequestParameterError,
                    $"找不到該組合產品項目的id: {id}");
            }

            return compositeProductItem;
        }
    }
}
