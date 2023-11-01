using EShopAPI.Cores.EShopUnits.DTOs;

namespace EShopAPI.Cores.EShopUnits.DAOs
{
    /// <summary>
    /// 商店單位的 DAO Interface
    /// </summary>
    public interface IEShopUnitDao
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
        /// <param name="eShopUnit">要新增的實體</param>
        /// <returns></returns>
        Task<EShopUnit> InsertAsync(EShopUnit eShopUnit);

        /// <summary>
        /// 編輯商店單位
        /// </summary>
        /// <param name="eShopUnit">要編輯的實體</param>
        /// <returns></returns>
        Task UpdateAsync(EShopUnit eShopUnit);
    }
}
