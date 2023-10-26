using EShopAPI.Cores.Products.DTOs;
using EShopCores.Errors;

namespace EShopAPI.Cores.Products.Services
{
    /// <summary>
    /// 產品 Service Interface
    /// </summary>
    public interface IProductService
    {
        /// <summary>
        /// 查詢產品
        /// </summary>
        /// <param name="queryDto">搜尋條件</param>
        /// <returns></returns>
        IQueryable<Product> Get(QueryProductDto queryDto);

        /// <summary>
        /// 根據id查詢產品
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Product?> GetByIdAsync(long id);

        /// <summary>
        /// 根據庫存id查詢產品
        /// </summary>
        /// <param name="shopInventoryId">商品庫存id</param>
        /// <returns></returns>
        Task<Product?> GetByShopInventoryIdAsync(long shopInventoryId);

        /// <summary>
        /// 新增產品
        /// </summary>
        /// <param name="insertDto">要新增的產品資訊</param>
        /// <returns></returns>
        Task<Product> InsertAsync(InsertProductDto insertDto);

        /// <summary>
        /// 編輯產品
        /// </summary>
        /// <param name="updateDto">要編輯的產品資訊</param>
        /// <returns></returns>
        Task UpdateAsync(UpdateProductDto updateDto);

        /// <summary>
        /// 刪除產品
        /// </summary>
        /// <param name="id">要刪除的產品id</param>
        /// <returns></returns>
        Task DeleteAsync(long id);

        /// <summary>
        /// 根據id取得產品，但若找不到id會直接throw exception
        /// </summary>
        /// <param name="id">產品id</param>
        /// <returns></returns>
        /// <exception cref="EShopException">找不到id</exception>
        Task<Product> ThrowNotFindByIdAsync(long id);

        /// <summary>
        /// 根據庫存id取得產品，若有找到產品資訊會直接throw exception
        /// </summary>
        /// <param name="shopInventoryId">商店庫存id</param>
        /// <returns></returns>
        /// <exception cref="EShopException">商店庫存id已存在</exception>
        Task<Product> ThrowExistShopInventoryIdAsync(long shopInventoryId);
    }
}
