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
        private readonly IShopUserDAO _shopUserDAO; 

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="shopUserDAO"></param>
        public ShopUserService(IShopUserDAO shopUserDAO) 
        {
            _shopUserDAO = shopUserDAO;
        }

        ///<inheritdoc/>
        public IQueryable<ShopUser> Get(QueryShopUserDTO queryDTO)
        {
            return _shopUserDAO.Get(queryDTO);
        }

        ///<inheritdoc/>
        public async Task<ShopUser?> GetByNumberAsync(string number)
        {
            return await _shopUserDAO.GetByNumberAsync(number);
        }

        ///<inheritdoc/>
        public async Task<ShopUser> InsertAsync(InsertShopUserDTO insertDTO)
        {
            ShopUser? shopUser = await _shopUserDAO.GetByNumberAsync(insertDTO.Number);
            if (shopUser != null)
            {
                throw new EShopException(ResponseCodeType.DuplicateData, "帳號已存在");
            };

            return await _shopUserDAO.InsertAsync(insertDTO.ToEntity());
        }
    }
}
