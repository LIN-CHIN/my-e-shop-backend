using EShopAPI.Context;
using EShopAPI.Cores.CompositeProducts.DTOs;
using EShopAPI.Cores.ShopInventories;
using Microsoft.EntityFrameworkCore;

namespace EShopAPI.Cores.CompositeProducts.DAOs
{
    /// <summary>
    /// 組合產品 DAO
    /// </summary>
    public class CompositeProductDao : ICompositeProductDao
    {
        private readonly EShopContext _eShopContext;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="eShopContext"></param>
        public CompositeProductDao(EShopContext eShopContext) 
        {
            _eShopContext = eShopContext;
        }

        ///<inheritdoc/>
        public IQueryable<CompositeProduct> Get(QueryCompositeProductDto queryDto)
        {
            IQueryable<CompositeProduct> compositeProducts = _eShopContext.CompositeProduct;


            if (queryDto.ShopInventoryId != null) 
            {
                compositeProducts = compositeProducts
                    .Where(cp => cp.ShopInventoryId == queryDto.ShopInventoryId);
            }

            if(queryDto.EShopUnitId != null)
            {
                compositeProducts = compositeProducts
                    .Where(cp => cp.EShopUnitId == queryDto.EShopUnitId);
            }

            if(queryDto.IsUseCoupon != null)
            {
                compositeProducts = compositeProducts
                    .Where(cp => cp.IsUseCoupon == queryDto.IsUseCoupon);
            }
            
            return compositeProducts;
        }

        ///<inheritdoc/>
        public async Task<CompositeProduct?> GetByIdAsync(long id)
        {
            return await _eShopContext.CompositeProduct
                .Where(cp => cp.Id == id)
                .SingleOrDefaultAsync();
        }

        ///<inheritdoc/>
        public async Task<CompositeProduct?> GetByShopInventoryIdAsync(long shopInventoryId)
        {
            return await _eShopContext.CompositeProduct
                  .Where(cp => cp.ShopInventoryId == shopInventoryId)
                  .SingleOrDefaultAsync();
        }

        ///<inheritdoc/>
        public async Task<CompositeProduct> InsertAsync(CompositeProduct compositeProduct)
        {
            _eShopContext.CompositeProduct.Add(compositeProduct);
            await _eShopContext.SaveChangesAsync();
            return compositeProduct;
        }

        ///<inheritdoc/>
        public async Task UpdateAsync(CompositeProduct compositeProduct)
        {
            _eShopContext.CompositeProduct.Update(compositeProduct);
            await _eShopContext.SaveChangesAsync();
        }

        ///<inheritdoc/>
        public async Task DeleteAsync(CompositeProduct compositeProduct)
        {
            _eShopContext.CompositeProduct.Remove(compositeProduct);
            await _eShopContext.SaveChangesAsync();
        }
    }
}
