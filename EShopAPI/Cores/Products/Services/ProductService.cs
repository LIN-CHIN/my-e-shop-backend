using EShopAPI.Common;
using EShopAPI.Cores.Products.DAOs;
using EShopAPI.Cores.Products.DTOs;

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
            throw new NotImplementedException();
        }

        ///<inheritdoc/>
        public Task<Product?> GetByIdAsync(long id)
        {
            throw new NotImplementedException();
        }

        ///<inheritdoc/>
        public Task<Product?> GetByShopInventoryIdAsync(long shopInventoryId)
        {
            throw new NotImplementedException();
        }

        ///<inheritdoc/>
        public Task<Product> InsertAsync(InsertProductDto insertDto)
        {
            throw new NotImplementedException();
        }

        ///<inheritdoc/>
        public Task UpdateAsync(UpdateProductDto updateDto)
        {
            throw new NotImplementedException();
        }

        ///<inheritdoc/>
        public Task DeleteAsync(long id)
        {
            throw new NotImplementedException();
        }

        ///<inheritdoc/>
        public Task<Product> ThrowExistShopInventoryIdAsync(long shopInventoryId)
        {
            throw new NotImplementedException();
        }

        ///<inheritdoc/>
        public Task<Product> ThrowNotFindByIdAsync(long id)
        {
            throw new NotImplementedException();
        }
    }
}
