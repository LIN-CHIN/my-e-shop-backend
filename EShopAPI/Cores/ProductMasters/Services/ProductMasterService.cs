using EShopAPI.Cores.ProductMasters.DAOs;
using EShopAPI.Cores.ProductMasters.DTOs;
using EShopAPI.Cores.ShopUsers;
using EShopCores.Errors;
using EShopCores.Extensions;
using EShopCores.Responses;

namespace EShopAPI.Cores.ProductMasters.Services
{
    /// <summary>
    /// 產品主檔的 Service
    /// </summary>
    public class ProductMasterService : IProductMasterService
    {
        private readonly IProductMasterDao _productMasterDao;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="productMasterDao"></param>
        public ProductMasterService(IProductMasterDao productMasterDao) 
        {
            _productMasterDao = productMasterDao;
        }

        ///<inheritdoc/>
        public async Task<ProductMaster?> GetByIdAsync(long id)
        {
            return await _productMasterDao.GetByIdAsync(id);
        }

        ///<inheritdoc/>
        public async Task<ProductMaster?> GetByNumberAsync(string number)
        {
            return await _productMasterDao.GetByNumberAsync(number);
        }

        ///<inheritdoc/>
        public async Task ThrowExistByNumberAsync(string number)
        {
            ProductMaster? productMaster = await _productMasterDao.GetByNumberAsync(number);
            if (productMaster != null)
            {
                throw new EShopException(
                    ResponseCodeType.DuplicateData,
                    $"該主產品代碼已存在: {number}");
            }
        }

        ///<inheritdoc/>
        public async Task<ProductMaster> ThrowNotFindByIdAsync(long id)
        {
            ProductMaster? productMaster = await _productMasterDao.GetByIdAsync(id);
            if (productMaster == null) 
            {
                throw new EShopException(
                    ResponseCodeType.RequestParameterError,
                    $"找不到該產品主檔id: {id}");
            }

            return productMaster;
        }

        ///<inheritdoc/>
        public async Task<ProductMaster> InsertAsync(InsertProductMasterDto insertDto)
        {
            await ThrowExistByNumberAsync(insertDto.Number);
            return await _productMasterDao.InsertAsync(insertDto.ToEntity());
        }

        ///<inheritdoc/>
        public async Task UpdateAsync(UpdateProductMasterDto updateDto)
        {
            ProductMaster productMaster = await ThrowNotFindByIdAsync(updateDto.Id);
            await _productMasterDao.UpdateAsync(updateDto.SetEntity(productMaster));
        }

        ///<inheritdoc/>
        public async Task EnableAsync(long id, bool isEnable)
        {
            ProductMaster productMaster = await ThrowNotFindByIdAsync(id);
            productMaster.IsEnable = isEnable;
            productMaster.UpdateDate = DateTime.UtcNow.GetUnixTimeMillisecond();
            await _productMasterDao.UpdateAsync(productMaster);
        }
    }
}
