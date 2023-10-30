using EShopAPI.Common;
using EShopAPI.Cores.CompositeProducts.DAOs;
using EShopAPI.Cores.CompositeProducts.DTOs;
using EShopAPI.Cores.ShopInventories;
using EShopCores.Errors;
using EShopCores.Responses;

namespace EShopAPI.Cores.CompositeProducts.Services
{
    /// <summary>
    /// 組合產品 Service
    /// </summary>
    public class CompositeProductService : ICompositeProductService
    {
        private readonly ICompositeProductDao _compositeProductDao;
        private readonly LoginUserData _loginUserData;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="compositeProductDao"></param>
        /// <param name="loginUserData"></param>
        public CompositeProductService(
            ICompositeProductDao compositeProductDao,
            LoginUserData loginUserData) 
        {
            _compositeProductDao = compositeProductDao;
            _loginUserData = loginUserData;
        }

        ///<inheritdoc/>
        public IQueryable<CompositeProduct> Get(QueryCompositeProductDto queryDto)
        {
            return _compositeProductDao.Get(queryDto);
        }

        ///<inheritdoc/>
        public async Task<CompositeProduct?> GetByIdAsync(long id)
        {
            return await _compositeProductDao.GetByIdAsync(id);
        }

        ///<inheritdoc/>
        public async Task<CompositeProduct?> GetByShopInventoryIdAsync(long shopInventoryId)
        {
            return await _compositeProductDao.GetByShopInventoryIdAsync(shopInventoryId);
        }

        ///<inheritdoc/>
        public async Task<CompositeProduct> InsertAsync(InsertCompositeProductDto insertDto)
        {
            await ThrowExistShopInventoryIdAsync(insertDto.ShopInventoryId);
            return await _compositeProductDao
                .InsertAsync(insertDto
                    .ToEntity(_loginUserData.UserNumber));
        }

        ///<inheritdoc/>
        public async Task UpdateAsync(UpdateCompositeProductDto updateDto)
        {
            CompositeProduct compositeProduct = await ThrowNotFindByIdAsync(updateDto.Id);
            await _compositeProductDao
                .UpdateAsync(updateDto
                    .SetEntity(compositeProduct, _loginUserData.UserNumber));
        }

        ///<inheritdoc/>
        public async Task ThrowExistShopInventoryIdAsync(long shopInventoryId)
        {
            CompositeProduct? compositeProduct = 
                await _compositeProductDao.GetByShopInventoryIdAsync(shopInventoryId);

            if (compositeProduct != null) 
            {
                throw new EShopException(ResponseCodeType.DuplicateData,
                    $"該商店庫存id已存在: {shopInventoryId}");
            }
        }

        ///<inheritdoc/>
        public async Task<CompositeProduct> ThrowNotFindByIdAsync(long id)
        {
            CompositeProduct? compositeProduct =
                await _compositeProductDao.GetByIdAsync(id);

            if (compositeProduct == null)
            {
                throw new EShopException(ResponseCodeType.RequestParameterError,
                    $"該id不存在: {id}");
            }

            return compositeProduct;
        }
    }
}
