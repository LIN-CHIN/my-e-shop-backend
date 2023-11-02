using EShopAPI.Cores.EShopUnits.DTOs;
using EShopCores.Errors;

namespace EShopAPI.Cores.EShopUnits.Services
{
    /// <summary>
    /// 商店單位的 Service Interface
    /// </summary>
    public interface IEShopUnitService
    {
        /// <summary>
        /// 查詢商店單位
        /// </summary>
        /// <param name="queryDto">搜尋條件</param>
        /// <returns></returns>
        IQueryable<EShopUnit> Get(QueryEShopUnitDto queryDto);

        /// <summary>
        /// 根據id查詢商店單位
        /// </summary>
        /// <param name="id">商店單位的id</param>
        /// <returns></returns>
        Task<EShopUnit?> GetByIdAsync(long id);

        /// <summary>
        /// 根據number查詢商店單位
        /// </summary>
        /// <param name="number">商店單位的number</param>
        /// <returns></returns>
        Task<EShopUnit?> GetByNumberAsync(string number);

        /// <summary>
        /// 新增商店單位
        /// </summary>
        /// <param name="insertDto">要新增的資料</param>
        /// <returns></returns>
        Task<EShopUnit> InsertAsync(InsertEShopUnitDto insertDto);

        /// <summary>
        /// 編輯商店單位
        /// </summary>
        /// <param name="updateDto">要編輯的資料</param>
        /// <returns></returns>
        Task UpdateAsync(UpdateEShopUnitDto updateDto);

        /// <summary>
        /// 啟用/停用商店單位
        /// </summary>
        /// <param name="id">要啟用/停用的商店單位id</param>
        /// <param name="isEnable">true = 啟用, false = 停用</param>
        /// <returns></returns>
        Task EnableAsync(long id, bool isEnable);

        /// <summary>
        /// 根據id取得實體，但若找不到id會直接throw exception
        /// </summary>
        /// <param name="id">商店單位的id</param>
        /// <returns></returns>
        /// <exception cref="EShopException">找不到id</exception>
        Task<EShopUnit> ThrowNotFindByIdAsync(long id);

        /// <summary>
        /// 根據商店單位的number取得實體，若有找到商店單位的資訊會直接throw exception
        /// </summary>
        /// <param name="number">商店單位代碼</param>
        /// <returns></returns>
        /// <exception cref="EShopException">商店單位Number已存在</exception>
        Task ThrowExistByNumberAsync(string number);
    }
}
