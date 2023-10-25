using EShopAPI.Context;
using EShopAPI.Cores.CustomVariantAttributes.DTOs;

namespace EShopAPI.Cores.CustomVariantAttributes.DAOs
{
    /// <summary>
    /// 自訂變種屬性的 DAO
    /// </summary>
    public class CustomVariantAttributeDao : ICustomVariantAttributeDao
    {
        private readonly EShopContext _eShopContext;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="eShopContext"></param>
        public CustomVariantAttributeDao(EShopContext eShopContext) 
        {
            _eShopContext = eShopContext;
        }

        ///<inheritdoc/>
        public IQueryable<CustomVariantAttribute> Get(QueryCustomVariantAttributeDto queryDto)
        {
            throw new NotImplementedException();
        }

        ///<inheritdoc/>
        public Task<CustomVariantAttribute?> GetByIdAsync(long id)
        {
            throw new NotImplementedException();
        }

        ///<inheritdoc/>
        public Task<CustomVariantAttribute?> GetByNumberAsync(string number)
        {
            throw new NotImplementedException();
        }

        ///<inheritdoc/>
        public Task<CustomVariantAttribute> InsertAsync(CustomVariantAttribute entity)
        {
            throw new NotImplementedException();
        }

        ///<inheritdoc/>
        public Task UpdateAsync(CustomVariantAttribute entity)
        {
            throw new NotImplementedException();
        }
    }
}
