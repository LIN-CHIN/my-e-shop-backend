using EShopAPI.Common;
using EShopAPI.Cores.CustomVariantAttributes.DAOs;
using EShopAPI.Cores.CustomVariantAttributes.DTOs;

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
        public Task<CustomVariantAttribute> InsertAsync(InsertCustomVariantAttributeDto insertDto)
        {
            throw new NotImplementedException();
        }

        ///<inheritdoc/>
        public Task UpdateAsync(UpdateCustomVariantAttributeDto updateDto)
        {
            throw new NotImplementedException();
        }

        ///<inheritdoc/>
        public Task EnableAsync(long id, bool isEnable)
        {
            throw new NotImplementedException();
        }

        ///<inheritdoc/>
        public Task<CustomVariantAttribute> ThrowNotFindByIdAsync(long id)
        {
            throw new NotImplementedException();
        }

        ///<inheritdoc/>
        public Task ThrowExistByNumberAsync(string number)
        {
            throw new NotImplementedException();
        }
    }
}
