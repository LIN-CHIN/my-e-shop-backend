using EShopAPI.Context;
using EShopAPI.Cores.EShopUnits.DTOs;
using Microsoft.EntityFrameworkCore;

namespace EShopAPI.Cores.EShopUnits.DAOs
{
    /// <summary>
    /// 商店單位的 DAO
    /// </summary>
    public class EShopUnitDao : IEShopUnitDao
    {
        private readonly EShopContext _eShopContext;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="eShopContext"></param>
        public EShopUnitDao(EShopContext eShopContext) 
        {
            _eShopContext = eShopContext;
        }

        ///<inheritdoc/>
        public IQueryable<EShopUnit> Get(QueryEShopUnitDto queryDto)
        {
            IQueryable<EShopUnit> eShopUnits = _eShopContext.EShopUnits;

            if (!string.IsNullOrWhiteSpace(queryDto.Number)) 
            {
                eShopUnits = eShopUnits
                    .Where(e => EF.Functions.Like(e.Number, $"%{queryDto.Number}%"));
            }

            if (!string.IsNullOrWhiteSpace(queryDto.Name))
            {
                eShopUnits = eShopUnits
                    .Where(e => EF.Functions.Like(e.Name, $"%{queryDto.Name}%"));
            }

            if (queryDto.IsEnable != null) 
            {
                eShopUnits = eShopUnits.Where(e => e.IsEnable == queryDto.IsEnable);
            }

            if (queryDto.IsSystemDefault != null)
            {
                eShopUnits = eShopUnits.Where(e => e.IsSystemDefault == queryDto.IsSystemDefault);
            }

            return eShopUnits;
        }

        ///<inheritdoc/>
        public async Task<EShopUnit?> GetByIdAsync(long id)
        {
            return await _eShopContext.EShopUnits
                .Where(e => e.Id == id)
                .SingleOrDefaultAsync();
        }

        ///<inheritdoc/>
        public async Task<EShopUnit?> GetByNumberAsync(string number)
        {
            return await _eShopContext.EShopUnits
                .Where(e => e.Number == number)
                .SingleOrDefaultAsync();
        }

        ///<inheritdoc/>
        public async Task<EShopUnit> InsertAsync(EShopUnit eShopUnit)
        {
            _eShopContext.EShopUnits.Add(eShopUnit);
            await _eShopContext.SaveChangesAsync();
            return eShopUnit;
        }

        ///<inheritdoc/>
        public async Task UpdateAsync(EShopUnit eShopUnit)
        {
            _eShopContext.EShopUnits.Update(eShopUnit);
            await _eShopContext.SaveChangesAsync();
        }
    }
}
