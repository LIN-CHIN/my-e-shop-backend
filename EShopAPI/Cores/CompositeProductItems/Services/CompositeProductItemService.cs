using EShopAPI.Common;
using EShopAPI.Cores.CompositeProductItems.DAOs;
using EShopAPI.Cores.CompositeProductItems.DTOs;
using EShopAPI.Cores.CompositeProducts.Services;
using EShopAPI.Cores.ShopInventories.Services;

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
            throw new NotImplementedException();
        }

        ///<inheritdoc/>
        public IQueryable<CompositeProductItem> GetByCompositeProductId(long compositeProductId)
        {
            throw new NotImplementedException();
        }

        ///<inheritdoc/>
        public Task<CompositeProductItem?> GetByIdAsync(long id)
        {
            throw new NotImplementedException();
        }

        ///<inheritdoc/>
        public Task<CompositeProductItem> InsertAsync(InsertCompositeProductItemDto insertDto)
        {
            throw new NotImplementedException();
        }

        ///<inheritdoc/>
        public Task UpdateAsync(UpdateCompositeProductItemDto upadteDto)
        {
            throw new NotImplementedException();
        }

        ///<inheritdoc/>
        public Task DeleteAsync(long id)
        {
            throw new NotImplementedException();
        }

        ///<inheritdoc/>
        public Task<CompositeProductItem> ThrowNotFindByIdAsync(long id)
        {
            throw new NotImplementedException();
        }
    }
}
