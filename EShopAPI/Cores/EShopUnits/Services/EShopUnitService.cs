using EShopAPI.Cores.EShopUnits.DTOs;

namespace EShopAPI.Cores.EShopUnits.Services
{
    /// <summary>
    /// 商店單位的 Service
    /// </summary>
    public class EShopUnitService : IEShopUnitService
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
        public Task<EShopUnit> InsertAsync(InsertEShopUnitDto insertDto)
        {
            throw new NotImplementedException();
        }

        ///<inheritdoc/>
        public Task UpdateAsync(UpdateEShopUnitDto updateDto)
        {
            throw new NotImplementedException();
        }

        ///<inheritdoc/>
        public Task EnableAsync(long id, bool isEnable)
        {
            throw new NotImplementedException();
        }

        ///<inheritdoc/>
        public Task ThrowExistByNumberAsync(long number)
        {
            throw new NotImplementedException();
        }

        ///<inheritdoc/>
        public Task<EShopUnit> ThrowNotFindByIdAsync(long id)
        {
            throw new NotImplementedException();
        }
    }
}
