using EShopAPI.Cores.CompositeProductItems.DTOs;

namespace EShopAPI.Cores.CompositeProductItems.DAOs
{
    /// <summary>
    /// 組合產品項目的 DAO Interface
    /// </summary>
    public interface ICompositeProductItemDao
    {
        /// <summary>
        /// 查詢組合產品項目
        /// </summary>
        /// <param name="queryDto">搜尋條件</param>
        /// <returns></returns>
        IQueryable<CompositeProductItem> Get(QueryCompositeProductItemDto queryDto);

        /// <summary>
        /// 根據組合產品的id查詢實體
        /// </summary>
        /// <param name="compositeProductId">組合產品的id</param>
        /// <returns></returns>
        IQueryable<CompositeProductItem> GetByCompositeProductId(long compositeProductId);

        /// <summary>
        /// 根據組合產品項目的id查詢實體
        /// </summary>
        /// <param name="id">組合產品項目的id</param>
        /// <returns></returns>
        Task<CompositeProductItem?> GetByIdAsync(long id);

        /// <summary>
        /// 新增組合產品項目
        /// </summary>
        /// <param name="compositeProductItem">要新增的組合產品項目實體</param>
        /// <returns></returns>
        Task<CompositeProductItem> InsertAsync(CompositeProductItem compositeProductItem);

        /// <summary>
        /// 編輯組合產品項目
        /// </summary>
        /// <param name="compositeProductItem">要編輯的組合產品項目實體</param>
        /// <returns></returns>
        Task UpdateAsync(CompositeProductItem compositeProductItem);

        /// <summary>
        /// 刪除組合產品項目
        /// </summary>
        /// <param name="compositeProductItem">要刪除的組合產品項目實體</param>
        /// <returns></returns>
        Task DeleteAsync(CompositeProductItem compositeProductItem);
    }
}
