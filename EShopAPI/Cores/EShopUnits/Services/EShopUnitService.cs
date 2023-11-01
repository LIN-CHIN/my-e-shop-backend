using EShopAPI.Common;
using EShopAPI.Cores.EShopUnits.DAOs;
using EShopAPI.Cores.EShopUnits.DTOs;

namespace EShopAPI.Cores.EShopUnits.Services
{
    /// <summary>
    /// 商店單位的 Service
    /// </summary>
    public class EShopUnitService : IEShopUnitService
    {
        private readonly IEShopUnitDao _eShopUnitDao;
        private readonly LoginUserData _loginUserData;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="eShopUnitDao"></param>
        /// <param name="loginUserData"></param>
        public EShopUnitService(IEShopUnitDao eShopUnitDao,
            LoginUserData loginUserData) 
        {
            _eShopUnitDao = eShopUnitDao;
            _loginUserData = loginUserData;
        }

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
        public Task ThrowExistByNumberAsync(string number)
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
