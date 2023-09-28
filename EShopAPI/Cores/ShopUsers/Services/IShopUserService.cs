using EShopAPI.Cores.ShopUsers.DTOs;

namespace EShopAPI.Cores.ShopUsers.Services
{
    /// <summary>
    /// 使用者的 Service Interface
    /// </summary>
    public interface IShopUserService
    {
        /// <summary>
        /// 取得使用者
        /// </summary>
        /// <param name="queryDTO"></param>
        /// <returns></returns>
        IQueryable<ShopUser> Get(QueryShopUserDTO queryDTO);

        /// <summary>
        /// 根據id取得使用者
        /// </summary>
        /// <param name="id">使用者的id</param>
        /// <returns></returns>
        Task<ShopUser?> GetByIdAsync(long id);

        /// <summary>
        /// 根據帳號取得使用者
        /// </summary>
        /// <param name="number">帳號</param>
        /// <returns></returns>
        Task<ShopUser?> GetByNumberAsync(string number);

        /// <summary>
        /// 新增使用者
        /// </summary>
        /// <param name="insertDTO">要新增的使用者資料</param>
        /// <returns></returns>
        Task<ShopUser> InsertAsync(InsertShopUserDTO insertDTO);

        /// <summary>
        /// 編輯使用者
        /// </summary>
        /// <param name="updateDTO">要編輯的使用者資料</param>
        /// <returns></returns>
        Task UpdaeAsync(UpdateShopUserDTO updateDTO);

        /// <summary>
        /// 啟用/停用使用者
        /// </summary>
        /// <param name="id">要啟用/停用的id</param>
        /// <param name="isEnable">是否啟用</param>
        /// <returns></returns>
        Task EnableAsync(long id, bool isEnable);
    }
}
