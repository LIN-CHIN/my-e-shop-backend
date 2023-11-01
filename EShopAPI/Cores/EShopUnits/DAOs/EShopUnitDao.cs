using EShopAPI.Cores.EShopUnits.DTOs;

namespace EShopAPI.Cores.EShopUnits.DAOs
{
    /// <summary>
    /// 商店單位的 DAO
    /// </summary>
    public class EShopUnitDao : IEShopUnitDao
    {
        ///<inheritdoc/>
        public IQueryable<EShopUnit> Get(QueryEShopUnitDto queryDto)
        {
            throw new NotImplementedException();
        }

        ///<inheritdoc/>
        public Task<EShopUnit?> GetByIdAsync(long id)
        {
            throw new NotImplementedException();
        }

        ///<inheritdoc/>
        public Task<EShopUnit?> GetByNumberAsync(string number)
        {
            throw new NotImplementedException();
        }

        ///<inheritdoc/>
        public Task<EShopUnit> InsertAsync(EShopUnit eShopUnit)
        {
            throw new NotImplementedException();
        }

        ///<inheritdoc/>
        public Task UpdateAsync(EShopUnit eShopUnit)
        {
            throw new NotImplementedException();
        }
    }
}
