using EShopAPI.Common;
using EShopAPI.Cores.EShopUnits.DAOs;
using EShopAPI.Cores.EShopUnits.DTOs;
using EShopCores.Errors;
using EShopCores.Extensions;
using EShopCores.Responses;

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
            return _eShopUnitDao.Get(queryDto);
        }

        ///<inheritdoc/>
        public Task<EShopUnit?> GetByIdAsync(long id)
        {
            return _eShopUnitDao.GetByIdAsync(id);
        }

        ///<inheritdoc/>
        public Task<EShopUnit?> GetByNumberAsync(string number)
        {
            return _eShopUnitDao.GetByNumberAsync(number);
        }

        ///<inheritdoc/>
        public async Task<EShopUnit> InsertAsync(InsertEShopUnitDto insertDto)
        {
            await ThrowExistByNumberAsync(insertDto.Number);
            return await _eShopUnitDao
                .InsertAsync(insertDto
                    .ToEntity(_loginUserData.UserNumber));
        }

        ///<inheritdoc/>
        public async Task UpdateAsync(UpdateEShopUnitDto updateDto)
        {
            EShopUnit eShopUnit = await ThrowNotFindByIdAsync(updateDto.Id);
            await _eShopUnitDao
                .UpdateAsync(updateDto
                    .SetEntity(eShopUnit, _loginUserData.UserNumber));
        }

        ///<inheritdoc/>
        public async Task EnableAsync(long id, bool isEnable)
        {
            EShopUnit eShopUnit = await ThrowNotFindByIdAsync(id);
            eShopUnit.IsEnable = isEnable;
            eShopUnit.UpdateDate = DateTime.UtcNow.GetUnixTimeMillisecond();
            eShopUnit.UpdateUser = _loginUserData.UserNumber;
            await _eShopUnitDao.UpdateAsync(eShopUnit);
        }

        ///<inheritdoc/>
        public async Task ThrowExistByNumberAsync(string number)
        {
            EShopUnit? eShopUnit = await _eShopUnitDao.GetByNumberAsync(number);
            if (eShopUnit != null) 
            {
                throw new EShopException(ResponseCodeType.DuplicateData,
                    $"該商店單位代碼已存在: {number}");
            }
        }

        ///<inheritdoc/>
        public async Task<EShopUnit> ThrowNotFindByIdAsync(long id)
        {
            EShopUnit? eShopUnit = await _eShopUnitDao.GetByIdAsync(id);
            if (eShopUnit == null)
            {
                throw new EShopException(ResponseCodeType.RequestParameterError,
                    $"該商店單位id不存在: {id}");
            }

            return eShopUnit;
        }
    }
}
