using EShopAPI.Cores.ShopUsers.DTOs;

namespace EShopAPI.Cores.ShopUsers.DAOs
{
    /// <summary>
    /// 使用者的 DAO Interface
    /// </summary>
    public interface IShopUserDao
    {
        /// <summary>
        /// 取得使用者
        /// </summary>
        /// <param name="queryDto"></param>
        /// <returns></returns>
        IQueryable<ShopUser> Get(QueryShopUserDto queryDto);

        /// <summary>
        /// 根據id取得使用者
        /// </summary>
        /// <param name="id">使用者的id</param>
        /// <returns></returns>
        Task<ShopUser?> GetByIdAsync(long id);

        /// <summary>
        /// 根據使用者帳號取得使用者實體
        /// </summary>
        /// <param name="number">使用者帳號</param>
        /// <returns></returns>
        Task<ShopUser?> GetByNumberAsync(string number);

        /// <summary>
        /// 新增使用者
        /// </summary>
        /// <param name="shopUser">要新增的使用者實體</param>
        /// <returns></returns>
        Task<ShopUser> InsertAsync(ShopUser shopUser);

        /// <summary>
        /// 編輯使用者
        /// </summary>
        /// <param name="shopUser">要編輯的使用者實體</param>
        /// <returns></returns>
        Task UpdaeAsync(ShopUser shopUser);
    }
}
