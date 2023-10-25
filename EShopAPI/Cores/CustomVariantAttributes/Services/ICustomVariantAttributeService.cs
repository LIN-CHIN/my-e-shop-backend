using EShopAPI.Cores.CustomVariantAttributes.DTOs;
using EShopCores.Errors;

namespace EShopAPI.Cores.CustomVariantAttributes.Services
{
    /// <summary>
    /// 自訂變種屬性的 Service Interface
    /// </summary>
    public interface ICustomVariantAttributeService
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
        /// <param name="insertDto">要新增自訂變種屬性的資料</param>
        /// <returns></returns>
        Task<CustomVariantAttribute> InsertAsync(InsertCustomVariantAttributeDto insertDto);

        /// <summary>
        /// 編輯自訂變種屬性
        /// </summary>
        /// <param name="updateDto">要編輯自訂變種屬性的資料</param>
        /// <returns></returns>
        Task UpdateAsync(UpdateCustomVariantAttributeDto updateDto);

        /// <summary>
        /// 啟用/停用自訂變種屬性
        /// </summary>
        /// <param name="id">要啟用/停用的id</param>
        /// <param name="isEnable">true = 啟用, false = 停用</param>
        /// <returns></returns>
        Task EnableAsync(long id, bool isEnable);

        /// <summary>
        /// 根據id取得自訂變種屬性，但若找不到該id會直接throw exception
        /// </summary>
        /// <param name="id">自訂變種屬性的id</param>
        /// <returns></returns>
        /// <exception cref="EShopException">找不到id</exception>
        Task<CustomVariantAttribute> ThrowNotFindByIdAsync(long id);

        /// <summary>
        /// 根據number取得自訂變種屬性，若找到已存在的number會直接throw exception
        /// </summary>
        /// <param name="number">自訂變種屬性的number</param>
        /// <returns></returns>
        /// <exception cref="EShopException">number已存在</exception>
        Task ThrowExistByNumberAsync(string number);
    }
}
