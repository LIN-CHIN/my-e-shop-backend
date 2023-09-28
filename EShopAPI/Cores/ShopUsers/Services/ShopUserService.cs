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
        private readonly IShopUserDao _shopUserDAO; 

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="shopUserDAO"></param>
        public ShopUserService(IShopUserDao shopUserDAO) 
        {
            _shopUserDAO = shopUserDAO;
        }

        ///<inheritdoc/>
        public IQueryable<ShopUser> Get(QueryShopUserDto queryDTO)
        {
            return _shopUserDAO.Get(queryDTO);
        }

        ///<inheritdoc/>
        public Task<ShopUser?> GetByIdAsync(long id)
        {
            return _shopUserDAO.GetByIdAsync(id);
        }

        ///<inheritdoc/>
        public async Task<ShopUser?> GetByNumberAsync(string number)
        {
            return await _shopUserDAO.GetByNumberAsync(number);
        }

        ///<inheritdoc/>
        public async Task<ShopUser> InsertAsync(InsertShopUserDto insertDTO)
        {
            ShopUser? shopUser = await _shopUserDAO.GetByNumberAsync(insertDTO.Number);
            if (shopUser != null)
            {
                throw new EShopException(ResponseCodeType.DuplicateData, "帳號已存在");
            }

            return await _shopUserDAO.InsertAsync(insertDTO.ToEntity());
        }

        ///<inheritdoc/>
        public async Task UpdaeAsync(UpdateShopUserDto updateDTO)
        {
            ShopUser? shopUser = await _shopUserDAO.GetByIdAsync(updateDTO.Id);

            if(shopUser == null)
            {
                throw new EShopException(
                    ResponseCodeType.RequestParameterError,
                    $"找不到使用者id :{updateDTO.Id}");
            }

            await _shopUserDAO.UpdaeAsync(updateDTO.SetEntity(shopUser));
        }

        ///<inheritdoc/>
        public async Task EnableAsync(long id, bool isEnable)
        {
            ShopUser? shopUser = await _shopUserDAO.GetByIdAsync(id);

            if (shopUser == null)
            {
                throw new EShopException(
                    ResponseCodeType.RequestParameterError,
                    $"找不到使用者id :{id}");
            }

            shopUser.IsEnable = isEnable;
            await _shopUserDAO.UpdaeAsync(shopUser);
        }
    }
}
