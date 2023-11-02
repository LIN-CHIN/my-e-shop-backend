using EShopAPI.Cores.CompositeProducts.DTOs;

namespace EShopAPI.Cores.CompositeProducts.Services
{
    /// <summary>
    /// 組合產品 Service Interface
    /// </summary>
    public interface ICompositeProductService
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
        /// <param name="insertDto">要新增的組合產品資訊</param>
        /// <returns></returns>
        Task<CompositeProduct> InsertAsync(InsertCompositeProductDto insertDto);

        /// <summary>
        /// 編輯組合產品
        /// </summary>
        /// <param name="updateDto">要編輯的組合產品資訊</param>
        /// <returns></returns>
        Task UpdateAsync(UpdateCompositeProductDto updateDto);

        /// <summary>
        /// 刪除組合產品
        /// </summary>
        /// <param name="id">要刪除的id</param>
        /// <returns></returns>
        Task DeleteAsync(long id);

        /// <summary>
        /// 啟用/停用組合產品
        /// </summary>
        /// <param name="id">要啟用/停用的id</param>
        /// <param name="isEnable"> 是否啟用/停用 true = 啟用, false = 停用 
        /// </param>
        /// <returns></returns>
        Task EnableAsync(long id, bool isEnable);

        /// <summary>
        /// 根據id取得組合產品，如果沒找到id 就會直接throw exception
        /// </summary>
        /// <param name="id">組合產品的id</param>
        /// <returns></returns>
        Task<CompositeProduct> ThrowNotFindByIdAsync(long id);

        /// <summary>
        /// 根據ShopInventoryId取得組合產品，如果沒找到id 就會直接throw exception
        /// </summary>
        /// <param name="shopInventoryId">商店庫存的id</param>
        /// <returns></returns>
        Task ThrowExistShopInventoryIdAsync(long shopInventoryId);
    } 
}
