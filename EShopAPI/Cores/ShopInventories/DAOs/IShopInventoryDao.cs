using EShopAPI.Cores.ShopInventories.DTOs;

namespace EShopAPI.Cores.ShopInventories.DAOs
{
    /// <summary>
    /// 商店庫存 DAO Interface
    /// </summary>
    public interface IShopInventoryDao
    {
        /// <summary>
        /// 查詢商店庫存
        /// </summary>
        /// <param name="queryDto">搜尋條件</param>
        /// <returns></returns>
        IQueryable<ShopInventory> Get(QueryShopInventoryDto queryDto);

        /// <summary>
        /// 根據id查詢商店庫存
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<ShopInventory?> GetByIdAsync(long id);

        /// <summary>
        /// 根據number查詢商店庫存
        /// </summary>
        /// <param name="number">商品代碼</param>
        /// <returns></returns>
        Task<ShopInventory?> GetByNumberAsync(string number);

        /// <summary>
        /// 新增商店庫存
        /// </summary>
        /// <param name="shopInventory">要新增的實體</param>
        /// <returns></returns>
        Task<ShopInventory> InsertAsync(ShopInventory shopInventory);

        /// <summary>
        /// 編輯商店庫存
        /// </summary>
        /// <param name="shopInventory">要編輯的實體</param>
        /// <returns></returns>
        Task UpdateAsync(ShopInventory shopInventory);

        /// <summary>
        /// 刪除商店庫存
        /// </summary>
        /// <param name="id">要刪除的id</param>
        /// <returns></returns>
        Task DeleteAsync(long id);
    }
}
