namespace EShopAPI.Cores.ProductMasters.DAOs
{
    /// <summary>
    /// 產品主檔的 DAO Interface
    /// </summary>
    public interface IProductMasterDao
    {
        /// <summary>
        /// 根據id取得產品主檔
        /// </summary>
        /// <param name="id">產品主檔的id</param>
        /// <returns></returns>
        Task<ProductMaster?> GetByIdAsync(long id);

        /// <summary>
        /// 根據產品主檔代碼取得產品主檔實體
        /// </summary>
        /// <param name="number">產品主檔代碼</param>
        /// <returns></returns>
        Task<ProductMaster?> GetByNumberAsync(string number);

        /// <summary>
        /// 新增產品主檔
        /// </summary>
        /// <param name="productMaster">要新增的產品主檔實體</param>
        /// <returns></returns>
        Task<ProductMaster> InsertAsync(ProductMaster productMaster);

        /// <summary>
        /// 編輯產品主檔
        /// </summary>
        /// <param name="productMaster">要編輯的產品主檔實體</param>
        /// <returns></returns>
        Task UpdateAsync(ProductMaster productMaster);
    }
}
