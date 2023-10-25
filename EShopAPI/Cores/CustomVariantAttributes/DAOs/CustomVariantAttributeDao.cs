using EShopAPI.Context;
using EShopAPI.Cores.CustomVariantAttributes.DTOs;
using Microsoft.EntityFrameworkCore;

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
            IQueryable<CustomVariantAttribute> entities = _eShopContext.CustomVariantAttributes;

            if (!string.IsNullOrWhiteSpace(queryDto.Number))
            {
                entities = entities
                    .Where(e => EF.Functions
                        .Like(e.Number, $"%{queryDto.Number}%"));            
            }

            if (!string.IsNullOrWhiteSpace(queryDto.Name))
            {
                entities = entities
                    .Where(e => EF.Functions
                        .Like(e.Name, $"%{queryDto.Name}%"));
            }

            if (queryDto.AttributeType != null) 
            {
                entities = entities.Where(e => 
                    e.AttributeType == queryDto.AttributeType);
            }

            if (queryDto.IsSystemDefault != null)
            {
                entities = entities.Where(e => 
                    e.IsSystemDefault == queryDto.IsSystemDefault);
            }

            if (queryDto.IsEnable != null)
            {
                entities = entities.Where(e => 
                    e.IsEnable == queryDto.IsEnable);
            }

            return entities;
        }

        ///<inheritdoc/>
        public async Task<CustomVariantAttribute?> GetByIdAsync(long id)
        {
            return await _eShopContext.CustomVariantAttributes
                .Where(cva => cva.Id == id)
                .SingleOrDefaultAsync();
        }

        ///<inheritdoc/>
        public async Task<CustomVariantAttribute?> GetByNumberAsync(string number)
        {
            return await _eShopContext.CustomVariantAttributes
                .Where(cva => cva.Number == number)
                .SingleOrDefaultAsync();
        }

        ///<inheritdoc/>
        public async Task<CustomVariantAttribute> InsertAsync(CustomVariantAttribute entity)
        {
            _eShopContext.CustomVariantAttributes.Add(entity);
            await _eShopContext.SaveChangesAsync();
            return entity;
        }

        ///<inheritdoc/>
        public async Task UpdateAsync(CustomVariantAttribute entity)
        {
            _eShopContext.CustomVariantAttributes.Update(entity);
            await _eShopContext.SaveChangesAsync();
        }
    }
}
