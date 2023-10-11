using EShopAPI.Cores.ProductMasters.DTOs;
using EShopCores.Errors;

namespace EShopAPI.Cores.ProductMasters.Services
{
    /// <summary>
    /// 產品主檔的 Service Interface
    /// </summary>
    public interface IProductMasterService
    {
        /// <summary>
        /// 根據id取得產品主檔
        /// </summary>
        /// <param name="id">產品主檔id</param>
        /// <returns></returns>
        Task<ProductMaster?> GetByIdAsync(long id);

        /// <summary>
        /// 根據Number取得產品主檔
        /// </summary>
        /// <param name="number">產品代碼</param>
        /// <returns></returns>
        Task<ProductMaster?> GetByNumberAsync(string number);

        /// <summary>
        /// 根據number取得產品主檔，如果找到number 就會直接throw exception
        /// </summary>
        /// <param name="number">產品主檔的代碼</param>
        /// <exception cref="EShopException">Number已存在</exception>
        /// <returns></returns>
        Task ThrowExistByNumberAsync(string number);

        /// <summary>
        /// 根據id取得產品主檔，如果沒找到id 就會直接throw exception
        /// </summary>
        /// <param name="id">產品主檔的id</param>
        /// <exception cref="EShopException">找不到該id</exception>
        /// <returns></returns>
        Task<ProductMaster> ThrowNotFindByIdAsync(long id);

        /// <summary>
        /// 新增產品主檔
        /// </summary>
        /// <param name="insertDto">要新增的資料</param>
        /// <returns></returns>
        Task<ProductMaster> InsertAsync(InsertProductMasterDto insertDto);

        /// <summary>
        /// 編輯產品主檔
        /// </summary>
        /// <param name="updateDto">要編輯的資料</param>
        /// <returns></returns>
        Task UpdateAsync(UpdateProductMasterDto updateDto);

        /// <summary>
        /// 啟用/停用產品主檔
        /// </summary>
        /// <param name="id">要停用/啟用的id</param>
        /// <param name="isEnable">true = 啟用, false = 停用</param>
        /// <returns></returns>
        Task EnableAsync(long id, bool isEnable);
    }
}
