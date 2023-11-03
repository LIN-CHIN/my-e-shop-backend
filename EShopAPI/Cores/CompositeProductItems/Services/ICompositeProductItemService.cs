using EShopAPI.Cores.CompositeProductItems.DTOs;

namespace EShopAPI.Cores.CompositeProductItems.Services
{
    /// <summary>
    /// 組合產品項目的 Service Interface
    /// </summary>
    public interface ICompositeProductItemService
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
        Task<CompositeProductItem?> GetById(long id);

        /// <summary>
        /// 新增組合產品項目
        /// </summary>
        /// <param name="insertDto">要新增的組合產品項目資訊</param>
        /// <returns></returns>
        Task<CompositeProductItem> Insert(InsertCompositeProductItemDto insertDto);

        /// <summary>
        /// 編輯組合產品項目
        /// </summary>
        /// <param name="upadteDto">要編輯的組合產品項目資訊</param>
        /// <returns></returns>
        Task Update(UpdateCompositeProductItemDto upadteDto);

        /// <summary>
        /// 刪除組合產品項目
        /// </summary>
        /// <param name="id">要刪除的組合產品項目id</param>
        /// <returns></returns>
        Task Delete(long id);

        /// <summary>
        /// 根據id取得組合產品項目，如果沒找到id 就會直接throw exception
        /// </summary>
        /// <param name="id">組合產品項目的id</param>
        /// <returns></returns>
        Task<CompositeProductItem> ThrowNotFindByIdAsync(long id);
    }
}
