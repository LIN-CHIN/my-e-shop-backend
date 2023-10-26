using EShopAPI.Cores.ShopInventories.DTOs;
using EShopAPI.Cores.ShopInventories;
using EShopAPI.Cores.Products.DTOs;

namespace EShopAPI.Cores.Products.DAOs
{
    /// <summary>
    /// 產品 DAO Interface
    /// </summary>
    public interface IProductDao
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
        /// <param name="product">要新增的實體</param>
        /// <returns></returns>
        Task<Product> InsertAsync(Product product);

        /// <summary>
        /// 編輯產品
        /// </summary>
        /// <param name="product">要編輯的實體</param>
        /// <returns></returns>
        Task UpdateAsync(Product product);

        /// <summary>
        /// 刪除產品
        /// </summary>
        /// <param name="product">要刪除的實體</param>
        /// <returns></returns>
        Task DeleteAsync(Product product);
    }
}
