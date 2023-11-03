using EShopAPI.Context;
using EShopAPI.Cores.CompositeProductItems.DTOs;

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
            throw new NotImplementedException();
        }

        ///<inheritdoc/>
        public IQueryable<CompositeProductItem> GetByCompositeProductId(long compositeProductId)
        {
            throw new NotImplementedException();
        }

        ///<inheritdoc/>
        public Task<CompositeProductItem?> GetById(long id)
        {
            throw new NotImplementedException();
        }

        ///<inheritdoc/>
        public Task<CompositeProductItem> InsertAsync(CompositeProductItem compositeProductItem)
        {
            throw new NotImplementedException();
        }

        ///<inheritdoc/>
        public Task UpdateAsync(CompositeProductItem compositeProductItem)
        {
            throw new NotImplementedException();
        }

        ///<inheritdoc/>
        public Task DeleteAsync(CompositeProductItem compositeProductItem)
        {
            throw new NotImplementedException();
        }
    }
}
