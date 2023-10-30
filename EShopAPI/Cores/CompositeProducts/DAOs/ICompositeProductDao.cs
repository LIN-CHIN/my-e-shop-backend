using EShopAPI.Cores.CompositeProducts.DTOs;

namespace EShopAPI.Cores.CompositeProducts.DAOs
{
    /// <summary>
    /// 組合產品 DAO Interface
    /// </summary>
    public interface ICompositeProductDao
    {
        /// <summary>
        /// 查詢組合產品
        /// </summary>
        /// <param name="queryDto">搜尋條件</param>
        /// <returns></returns>
        IQueryable<CompositeProduct> Get(QueryCompositeProductDto queryDto);

        /// <summary>
        /// 根據id取得組合產品
        /// </summary>
        /// <param name="id">組合產品的id</param>
        /// <returns></returns>
        Task<CompositeProduct?> GetByIdAsync(long id);

        /// <summary>
        /// 根據商店庫存id取得組合產品
        /// </summary>
        /// <param name="shopInventoryId">商店庫存id</param>
        /// <returns></returns>
        Task<CompositeProduct?> GetByShopInventoryIdAsync(long shopInventoryId);

        /// <summary>
        /// 新增組合產品
        /// </summary>
        /// <param name="compositeProduct">要新增的組合產品實體</param>
        /// <returns></returns>
        Task<CompositeProduct> InsertAsync(CompositeProduct compositeProduct);

        /// <summary>
        /// 編輯組合產品
        /// </summary>
        /// <param name="compositeProduct">要編輯的組合產品實體</param>
        /// <returns></returns>
        Task UpdateAsync(CompositeProduct compositeProduct);
    }
}
