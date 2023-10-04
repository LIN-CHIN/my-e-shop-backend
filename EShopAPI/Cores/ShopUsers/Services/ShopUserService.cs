using EShopAPI.Cores.ShopUsers.DAOs;
using EShopAPI.Cores.ShopUsers.DTOs;
using EShopCores.Errors;
using EShopCores.Responses;

namespace EShopAPI.Cores.ShopUsers.Services
{
    /// <summary>
    /// 使用者的 Service
    /// </summary>
    public class ShopUserService : IShopUserService
    {
        private readonly IShopUserDao _shopUserDao; 

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="shopUserDao"></param>
        public ShopUserService(IShopUserDao shopUserDao) 
        {
            _shopUserDao = shopUserDao;
        }

        ///<inheritdoc/>
        public IQueryable<ShopUser> Get(QueryShopUserDto queryDto)
        {
            return _shopUserDao.Get(queryDto);
        }

        ///<inheritdoc/>
        public Task<ShopUser?> GetByIdAsync(long id)
        {
            return _shopUserDao.GetByIdAsync(id);
        }

        ///<inheritdoc/>
        public async Task<ShopUser?> GetByNumberAsync(string number)
        {
            return await _shopUserDao.GetByNumberAsync(number);
        }

        ///<inheritdoc/>
        public async Task<ShopUser> InsertAsync(InsertShopUserDto insertDto)
        {
            ShopUser? shopUser = await _shopUserDao.GetByNumberAsync(insertDto.Number);
            if (shopUser != null)
            {
                throw new EShopException(ResponseCodeType.DuplicateData, "帳號已存在");
            }

            return await _shopUserDao.InsertAsync(insertDto.ToEntity());
        }

        ///<inheritdoc/>
        public async Task UpdaeAsync(UpdateShopUserDto updateDto)
        {
            ShopUser? shopUser = await _shopUserDao.GetByIdAsync(updateDto.Id);

            if(shopUser == null)
            {
                throw new EShopException(
                    ResponseCodeType.RequestParameterError,
                    $"找不到使用者id :{updateDto.Id}");
            }

            await _shopUserDao.UpdaeAsync(updateDto.SetEntity(shopUser));
        }

        ///<inheritdoc/>
        public async Task EnableAsync(long id, bool isEnable)
        {
            ShopUser? shopUser = await _shopUserDao.GetByIdAsync(id);

            if (shopUser == null)
            {
                throw new EShopException(
                    ResponseCodeType.RequestParameterError,
                    $"找不到使用者id :{id}");
            }

            shopUser.IsEnable = isEnable;
            await _shopUserDao.UpdaeAsync(shopUser);
        }
    }
}
