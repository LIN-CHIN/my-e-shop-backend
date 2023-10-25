using EShopAPI.Common;
using EShopAPI.Cores.CustomVariantAttributes.DAOs;
using EShopAPI.Cores.CustomVariantAttributes.DTOs;
using EShopCores.Errors;
using EShopCores.Extensions;
using EShopCores.Responses;

namespace EShopAPI.Cores.CustomVariantAttributes.Services
{
    /// <summary>
    /// 自訂變種屬性的 Service
    /// </summary>
    public class CustomVariantAttributeService : ICustomVariantAttributeService
    {
        private readonly ICustomVariantAttributeDao _customVariantAttributeDao;
        private readonly LoginUserData _loginUserData;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="customVariantAttributeDao"></param>
        /// <param name="loginUserData"></param>
        public CustomVariantAttributeService(
            ICustomVariantAttributeDao customVariantAttributeDao,
            LoginUserData loginUserData) 
        {
            _customVariantAttributeDao = customVariantAttributeDao;
            _loginUserData = loginUserData;
        }

        ///<inheritdoc/>
        public IQueryable<CustomVariantAttribute> Get(QueryCustomVariantAttributeDto queryDto)
        {
            return _customVariantAttributeDao.Get(queryDto);
        }

        ///<inheritdoc/>
        public async Task<CustomVariantAttribute?> GetByIdAsync(long id)
        {
            return await _customVariantAttributeDao.GetByIdAsync(id);
        }

        ///<inheritdoc/>
        public async Task<CustomVariantAttribute?> GetByNumberAsync(string number)
        {
            return await _customVariantAttributeDao.GetByNumberAsync(number);
        }

        ///<inheritdoc/>
        public async Task<CustomVariantAttribute> InsertAsync(InsertCustomVariantAttributeDto insertDto)
        {
            await ThrowExistByNumberAsync(insertDto.Number);
            return await _customVariantAttributeDao
                .InsertAsync(insertDto
                    .ToEntity(_loginUserData.UserNumber));
        }

        ///<inheritdoc/>
        public async Task UpdateAsync(UpdateCustomVariantAttributeDto updateDto)
        {
            CustomVariantAttribute entity = await ThrowNotFindByIdAsync(updateDto.Id);
            await _customVariantAttributeDao
                    .UpdateAsync(updateDto
                        .SetEntity(entity, _loginUserData.UserNumber));
        }

        ///<inheritdoc/>
        public async Task EnableAsync(long id, bool isEnable)
        {
            CustomVariantAttribute entity = await ThrowNotFindByIdAsync(id);
            entity.IsEnable = isEnable;
            entity.UpdateUser = _loginUserData.UserNumber;
            entity.UpdateDate = DateTime.UtcNow.GetUnixTimeMillisecond();

            await _customVariantAttributeDao.UpdateAsync(entity);
        }

        ///<inheritdoc/>
        public async Task<CustomVariantAttribute> ThrowNotFindByIdAsync(long id)
        {
            CustomVariantAttribute? entity = 
                await _customVariantAttributeDao.GetByIdAsync(id);

            if (entity == null) 
            {
                throw new EShopException(ResponseCodeType.RequestParameterError,
                    $"找不到id:{id}");
            }

            return entity;
        }

        ///<inheritdoc/>
        public async Task ThrowExistByNumberAsync(string number)
        {
            CustomVariantAttribute? entity = 
                await _customVariantAttributeDao.GetByNumberAsync(number);

            if (entity != null)
            {
                throw new EShopException(ResponseCodeType.DuplicateData,
                    $"number已存在");
            }
        }
    }
}
