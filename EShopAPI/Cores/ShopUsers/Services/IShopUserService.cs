using EShopAPI.Cores.ShopUsers.DTOs;

namespace EShopAPI.Cores.ShopUsers.Services
{
    /// <summary>
    /// 使用者的 Service Interface
    /// </summary>
    public interface IShopUserService
    {
        /// <summary>
        /// 新增使用者
        /// </summary>
        /// <param name="insertDTO">要新增的使用者資料</param>
        /// <returns></returns>
        Task<ShopUser> InsertAsync(InsertShopUserDTO insertDTO);
    }
}
