using EShopAPI.Context;
using EShopAPI.Cores.CompositeProductItems.DTOs;
using EShopAPI.Cores.CompositeProducts;
using Microsoft.EntityFrameworkCore;

namespace EShopAPI.Cores.CompositeProductItems.DAOs
{
    /// <summary>
    /// 組合產品項目的 DAO
    /// </summary>
    public class CompositeProductItemDao : ICompositeProductItemDao
    {
        private readonly EShopContext _eShopContext;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="eShopContext"></param>
        public CompositeProductItemDao(EShopContext eShopContext) 
        {
            _eShopContext = eShopContext;
        }

        ///<inheritdoc/>
        public IQueryable<CompositeProductItem> Get(QueryCompositeProductItemDto queryDto)
        {
            IQueryable<CompositeProductItem> compositeProductItems = _eShopContext.CompositeProductItems;

            if (queryDto.CompositeProductId != null) 
            {
                compositeProductItems = compositeProductItems
                    .Where(cpi => cpi.CompositeProductId == queryDto.CompositeProductId);
            }

            if (queryDto.ShopInventoryId != null)
            {
                compositeProductItems = compositeProductItems
                    .Where(cpi => cpi.ShopInventoryId == queryDto.ShopInventoryId);
            }

            if (queryDto.PriceScopeStart != null)
            {
                compositeProductItems = compositeProductItems
                    .Where(cpi => cpi.Price >= queryDto.PriceScopeStart);
            }

            if (queryDto.PriceScopeEnd != null)
            {
                compositeProductItems = compositeProductItems
                    .Where(cpi => cpi.Price <= queryDto.PriceScopeEnd);
            }

            if (queryDto.IsAlwaysSale != null)
            {
                compositeProductItems = compositeProductItems
                    .Where(cpi => cpi.IsAlwaysSale == queryDto.IsAlwaysSale);
            }

            if (queryDto.SaleStartDate != null)
            {
                compositeProductItems = compositeProductItems
                    .Where(cpi => cpi.SaleStartDate >= queryDto.SaleStartDate);
            }

            if (queryDto.SaleEndDate != null)
            {
                compositeProductItems = compositeProductItems
                    .Where(cpi => cpi.SaleEndDate <= queryDto.SaleEndDate);
            }

            return compositeProductItems;
        }

        ///<inheritdoc/>
        public IQueryable<CompositeProductItem> GetByCompositeProductId(long compositeProductId)
        {
            return _eShopContext.CompositeProductItems
                .Where(cpi => cpi.CompositeProductId == compositeProductId);
        }

        ///<inheritdoc/>
        public async Task<CompositeProductItem?> GetByIdAsync(long id)
        {
            return await _eShopContext.CompositeProductItems
                .Where(cpi => cpi.Id == id)
                .SingleOrDefaultAsync();
        }

        ///<inheritdoc/>
        public async Task<CompositeProductItem> InsertAsync(CompositeProductItem compositeProductItem)
        {
            _eShopContext.CompositeProductItems.Add(compositeProductItem);
            await _eShopContext.SaveChangesAsync();
            return compositeProductItem;
        }

        ///<inheritdoc/>
        public async Task UpdateAsync(CompositeProductItem compositeProductItem)
        {
            _eShopContext.CompositeProductItems.Update(compositeProductItem);
            await _eShopContext.SaveChangesAsync();
        }

        ///<inheritdoc/>
        public async Task DeleteAsync(CompositeProductItem compositeProductItem)
        {
            _eShopContext.CompositeProductItems.Remove(compositeProductItem);
            await _eShopContext.SaveChangesAsync();
        }
    }
}
