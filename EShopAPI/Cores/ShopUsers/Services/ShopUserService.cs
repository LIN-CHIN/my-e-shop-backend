using EShopAPI.Common;
using EShopAPI.Context;
using EShopAPI.Cores.ShopUsers.DAOs;
using EShopAPI.Cores.ShopUsers.DTOs;
using EShopCores.Errors;
using EShopCores.Extensions;
using EShopCores.Responses;

namespace EShopAPI.Cores.ShopUsers.Services
{
    /// <summary>
    /// 使用者的 Service
    /// </summary>
    public class ShopUserService : IShopUserService
    {
        private readonly IShopUserDao _shopUserDao;
        private readonly LoginUserData _loginUserData;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="shopUserDao"></param>
        /// <param name="loginUserData"></param>
        public ShopUserService(IShopUserDao shopUserDao, LoginUserData loginUserData) 
        {
            _shopUserDao = shopUserDao;
            _loginUserData = loginUserData;
        }

        ///<inheritdoc/>
        public IQueryable<ShopUser> Get(QueryShopUserDto queryDto)
        {
            return _shopUserDao.Get(queryDto);
        }

        ///<inheritdoc/>
        public async Task<ShopUser?> GetByIdAsync(long id)
        {
            return await _shopUserDao.GetByIdAsync(id);
        }

        ///<inheritdoc/>
        public async Task<ShopUser?> GetByNumberAsync(string number)
        {
            return await _shopUserDao.GetByNumberAsync(number);
        }

        ///<inheritdoc/>
        public async Task ThrowExistByNumberAsync(string number)
        {
            ShopUser? shopUser = await _shopUserDao.GetByNumberAsync(number);

            if (shopUser != null)
            {
                throw new EShopException(ResponseCodeType.DuplicateData, "帳號已存在");
            }
        }

        ///<inheritdoc/>
        public async Task<ShopUser> ThrowNotFindByIdAsync(long id)
        {
            ShopUser? shopUser = await _shopUserDao.GetByIdAsync(id);

            if (shopUser == null)
            {
                throw new EShopException(
                    ResponseCodeType.RequestParameterError,
                    $"找不到使用者id :{id}");
            }

            return shopUser;
        }

        ///<inheritdoc/>
        public async Task<ShopUser> ThrowNotFindByNumberAsync(string number)
        {
            ShopUser? shopUser = await _shopUserDao.GetByNumberAsync(number);

            if (shopUser == null)
            {
                throw new EShopException(ResponseCodeType.NotFindAccount, "帳號不存在");
            }

            return shopUser;
        }

        ///<inheritdoc/>
        public async Task<ShopUser> InsertAsync(InsertShopUserDto insertDto)
        {
            await ThrowExistByNumberAsync(insertDto.Number);
            return await _shopUserDao.InsertAsync(
                insertDto.ToEntity(_loginUserData.UserNumber)
            );
        }

        ///<inheritdoc/>
        public async Task UpdateAsync(UpdateShopUserDto updateDto)
        {
            ShopUser? shopUser = await ThrowNotFindByIdAsync(updateDto.Id);
            
            await _shopUserDao.UpdateAsync(
                updateDto.SetEntity(shopUser, _loginUserData.UserNumber)
            );
        }

        ///<inheritdoc/>
        public async Task EnableAsync(long id, bool isEnable)
        {
            ShopUser? shopUser = await ThrowNotFindByIdAsync(id);
            shopUser.IsEnable = isEnable;
            shopUser.UpdateUser = _loginUserData.UserNumber;
            shopUser.UpdateDate = DateTime.UtcNow.GetUnixTimeMillisecond();
            await _shopUserDao.UpdateAsync(shopUser);
        }
    }
}
