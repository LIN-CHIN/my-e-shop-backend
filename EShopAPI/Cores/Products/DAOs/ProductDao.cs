using EShopAPI.Context;
using EShopAPI.Cores.Products.DTOs;

namespace EShopAPI.Cores.Products.DAOs
{
    /// <summary>
    /// 產品 DAO
    /// </summary>
    public class ProductDao : IProductDao
    {
        private readonly EShopContext _eShopContext;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="eShopContext"></param>
        public ProductDao(EShopContext eShopContext) 
        {
            _eShopContext = eShopContext;
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
        public Task<Product> InsertAsync(Product product)
        {
            throw new NotImplementedException();
        }

        ///<inheritdoc/>
        public Task UpdateAsync(Product product)
        {
            throw new NotImplementedException();
        }

        ///<inheritdoc/>
        public Task DeleteAsync(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
