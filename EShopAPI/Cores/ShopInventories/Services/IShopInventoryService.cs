using EShopAPI.Cores.ShopInventories.DTOs;
using EShopAPI.Cores.ShopRoles;
using EShopCores.Errors;

namespace EShopAPI.Cores.ShopInventories.Services
{
    /// <summary>
    /// 商店庫存 Service Interface
    /// </summary>
    public interface IShopInventoryService
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
        /// <param name="insertDto">要新增的資料</param>
        /// <returns></returns>
        Task<ShopInventory> InsertAsync(InsertShopInventoryDto insertDto);

        /// <summary>
        /// 編輯商店庫存
        /// </summary>
        /// <param name="updateDto">要編輯的資料</param>
        /// <returns></returns>
        Task UpdateAsync(UpdateShopInventoryDto updateDto);

        /// <summary>
        /// 根據id取得商店庫存，但若找不到該id會直接throw exception
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="EShopException">找不到id</exception>
        Task<ShopInventory> ThrowNotFindByIdAsync(long id);

        /// <summary>
        /// 根據number取得商店庫存，但若找到number會直接throw exception
        /// </summary>
        /// <param name="number">商品代碼</param>
        /// <returns></returns>
        /// <exception cref="EShopException">找不到id</exception>
        Task ThrowExistByNumberAsync(string number);

        /// <summary>
        /// 啟用/停用商店庫存
        /// </summary>
        /// <param name="id"></param>
        /// <param name="isEnable"></param>
        /// <returns></returns>
        Task EnableAsync(long id, bool isEnable);
    }
}
