using EShopAPI.Common;
using EShopAPI.Cores.Products.DAOs;
using EShopAPI.Cores.Products.DTOs;
using EShopCores.Errors;
using EShopCores.Responses;

namespace EShopAPI.Cores.Products.Services
{
    /// <summary>
    /// 產品 Service
    /// </summary>
    public class ProductService : IProductService
    {
        private readonly IProductDao _productDao;
        private readonly LoginUserData _loginUserData;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="productDao"></param>
        /// <param name="loginUserData"></param>
        public ProductService(IProductDao productDao, LoginUserData loginUserData) 
        {
            _productDao = productDao;
            _loginUserData = loginUserData;
        }

        ///<inheritdoc/>
        public IQueryable<Product> Get(QueryProductDto queryDto)
        {
            return _productDao.Get(queryDto);
        }

        ///<inheritdoc/>
        public async Task<Product?> GetByIdAsync(long id)
        {
            return await _productDao.GetByIdAsync(id);
        }

        ///<inheritdoc/>
        public async Task<Product?> GetByShopInventoryIdAsync(long shopInventoryId)
        {
            return await _productDao.GetByShopInventoryIdAsync(shopInventoryId);
        }

        ///<inheritdoc/>
        public async Task<Product> InsertAsync(InsertProductDto insertDto)
        {
            await ThrowExistShopInventoryIdAsync(insertDto.ShopInventoryId);
            return await _productDao
                .InsertAsync(insertDto
                    .ToEntity(_loginUserData.UserNumber));
        }

        ///<inheritdoc/>
        public async Task UpdateAsync(UpdateProductDto updateDto)
        {
            Product product = await ThrowNotFindByIdAsync(updateDto.Id);
            await _productDao.UpdateAsync(updateDto
                .SetEntity(product, _loginUserData.UserNumber));
        }

        ///<inheritdoc/>
        public async Task DeleteAsync(long id)
        {
            Product product = await ThrowNotFindByIdAsync(id);
            await _productDao.DeleteAsync(product);
        }

        ///<inheritdoc/>
        public async Task<Product> ThrowNotFindByIdAsync(long id)
        {
            Product? product = await _productDao.GetByIdAsync(id);
            if (product == null) 
            {
                throw new EShopException(ResponseCodeType.RequestParameterError,
                    $"找不到該id: {id}");
            }

            return product;
        }

        ///<inheritdoc/>
        public async Task ThrowExistShopInventoryIdAsync(long shopInventoryId)
        {
            Product? prodcut =  await _productDao.GetByShopInventoryIdAsync(shopInventoryId);
            if (prodcut != null) 
            {
                throw new EShopException(ResponseCodeType.DuplicateData,
                       $"商店庫存已存在 shopInventoryId = {shopInventoryId}");
            }
        }
    }
}
