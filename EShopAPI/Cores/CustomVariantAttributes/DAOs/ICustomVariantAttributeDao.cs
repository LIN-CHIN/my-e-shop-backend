using EShopAPI.Cores.CustomVariantAttributes.DTOs;

namespace EShopAPI.Cores.CustomVariantAttributes.DAOs
{
    /// <summary>
    /// 自訂變種屬性的 DAO Interface
    /// </summary>
    public interface ICustomVariantAttributeDao
    {
        /// <summary>
        /// 查詢自訂變種屬性清單
        /// </summary>
        /// <param name="queryDto"></param>
        /// <returns></returns>
        IQueryable<CustomVariantAttribute> Get(QueryCustomVariantAttributeDto queryDto);

        /// <summary>
        /// 根據id查詢自訂變種屬性
        /// </summary>
        /// <param name="id">自訂變種屬性的id</param>
        /// <returns></returns>
        Task<CustomVariantAttribute?> GetByIdAsync(long id);

        /// <summary>
        /// 根據number查詢自訂變種屬性
        /// </summary>
        /// <param name="number">自訂變種屬性的number</param>
        /// <returns></returns>
        Task<CustomVariantAttribute?> GetByNumberAsync(string number);

        /// <summary>
        /// 新增自訂變種屬性
        /// </summary>
        /// <param name="entity">要新增自訂變種屬性的實體</param>
        /// <returns></returns>
        Task<CustomVariantAttribute> InsertAsync(CustomVariantAttribute entity);

        /// <summary>
        /// 編輯自訂變種屬性
        /// </summary>
        /// <param name="entity">要編輯自訂變種屬性的實體</param>
        /// <returns></returns>
        Task UpdateAsync(CustomVariantAttribute entity);
    }
}
