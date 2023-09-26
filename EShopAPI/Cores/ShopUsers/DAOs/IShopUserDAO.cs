namespace EShopAPI.Cores.ShopUsers.DAOs
{
    /// <summary>
    /// 使用者的 DAO Interface
    /// </summary>
    public interface IShopUserDAO
    {
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
    }
}
