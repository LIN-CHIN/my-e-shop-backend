using EShopAPI.Cores.ShopUsers.DTOs;
using EShopCores.Errors;

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
        /// 根據number取得使用者，如果找到number 就會直接throw exception
        /// </summary>
        /// <param name="number">使用者的代碼/帳號</param>
        /// <exception cref="EShopException">Number已存在</exception>
        /// <returns></returns>
        Task ThrowNotFindByNumberAsync(string number);

        /// <summary>
        /// 根據id取得使用者，如果沒找到id 就會直接throw exception
        /// </summary>
        /// <param name="id">使用者的id</param>
        /// <exception cref="EShopException">找不到該id</exception>
        /// <returns></returns>
        Task<ShopUser> ThrowNotFindByIdAsync(long id);

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
        Task UpdateAsync(ShopUser shopUser);
    }
}
