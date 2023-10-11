using EShopAPI.Context;
using EShopAPI.Cores.ProductMasters.DTOs;
using EShopCores.Enums;
using Microsoft.EntityFrameworkCore;

namespace EShopAPI.Cores.ProductMasters.DAOs
{
    /// <summary>
    /// 產品主檔的 DAO
    /// </summary>
    public class ProductMasterDao : IProductMasterDao
    {
        private readonly EShopContext _eShopContext;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="eShopContext"></param>
        public ProductMasterDao(EShopContext eShopContext) 
        {
            _eShopContext = eShopContext;
        }

        ///<inheritdoc/>
        public IQueryable<ProductMaster> Get(QueryProductMasterDto queryDto)
        {
            IQueryable<ProductMaster> productMasters = _eShopContext.ProductMasters;

            if (!string.IsNullOrWhiteSpace(queryDto.Number)) 
            {
                productMasters = productMasters
                    .Where(pm => EF.Functions.Like(pm.Number, $"%{queryDto.Number}%"));
            }

            if (!string.IsNullOrWhiteSpace(queryDto.Name))
            {
                productMasters = productMasters
                    .Where(pm => EF.Functions.Like(pm.Name, $"%{queryDto.Name}%"));
            }

            if (queryDto.ProductType != null)
            {
                productMasters = productMasters
                    .Where(pm => pm.ProductType == queryDto.ProductType);
            }

            if (queryDto.IsEnable != null)
            {
                productMasters = productMasters
                    .Where(pm => pm.IsEnable == queryDto.IsEnable);
            }

            return productMasters;
        }

        ///<inheritdoc/>
        public async Task<ProductMaster> InsertAsync(ProductMaster productMaster)
        {
            _eShopContext.ProductMasters.Add(productMaster);
            await _eShopContext.SaveChangesAsync();
            return productMaster;
        }

        ///<inheritdoc/>
        public async Task<ProductMaster?> GetByIdAsync(long id)
        {
            return await _eShopContext.ProductMasters
                .Where(pm => pm.Id == id)
                .SingleOrDefaultAsync();
        }

        ///<inheritdoc/>
        public async Task<ProductMaster?> GetByNumberAsync(string number)
        {
            return await _eShopContext.ProductMasters
                .Where(pm => pm.Number == number)
                .SingleOrDefaultAsync();
        }

        ///<inheritdoc/>
        public async Task UpdateAsync(ProductMaster productMaster)
        {
            _eShopContext.ProductMasters.Update(productMaster);
            await _eShopContext.SaveChangesAsync();
        }
    }
}
