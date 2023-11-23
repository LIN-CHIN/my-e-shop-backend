using EShopAPI.Context;
using EShopAPI.Cores.Products.DTOs;
using Microsoft.EntityFrameworkCore;

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
            IQueryable<Product> products = _eShopContext.Product;

            if (queryDto.PriceScopeStart != null)
            {
                products = products.Where(p => p.Price >= queryDto.PriceScopeStart);
            }

            if (queryDto.PriceScopeEnd != null)
            {
                products = products.Where(p => p.Price <= queryDto.PriceScopeEnd);
            }

            if (queryDto.SaleStartDate != null)
            {
                products = products.Where(p => p.SaleStartDate >= queryDto.SaleStartDate);
            }

            if (queryDto.SaleEndDate != null)
            {
                products = products.Where(p => p.SaleEndDate <= queryDto.SaleEndDate);
            }

            if (queryDto.IsEnable != null)
            {
                products = products.Where(p => p.IsEnable == queryDto.IsEnable );
            }

            return products;
        }

        ///<inheritdoc/>
        public async Task<Product?> GetByIdAsync(long id)
        {
            return await _eShopContext.Product
                .Where(p => p.Id == id)
                .SingleOrDefaultAsync();
        }

        ///<inheritdoc/>
        public async Task<Product?> GetByShopInventoryIdAsync(long shopInventoryId)
        {
            return await _eShopContext.Product
                .Where(p => p.ShopInventoryId == shopInventoryId)
                .SingleOrDefaultAsync();
        }

        ///<inheritdoc/>
        public async Task<Product> InsertAsync(Product product)
        {
            _eShopContext.Product.Add(product);
            await _eShopContext.SaveChangesAsync();
            return product; 
        }

        ///<inheritdoc/>
        public async Task UpdateAsync(Product product)
        {
            _eShopContext.Product.Update(product);
            await _eShopContext.SaveChangesAsync();
        }

        ///<inheritdoc/>
        public async Task DeleteAsync(Product product)
        {
            _eShopContext.Product.Remove(product);
            await _eShopContext.SaveChangesAsync();
        }
    }
}
