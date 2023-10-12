using EShopAPI.Cores.ProductMasters.Json;
using EShopAPI.Validations;
using EShopCores.Enums;
using EShopCores.Extensions;
using EShopCores.Json;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace EShopAPI.Cores.ProductMasters.DTOs
{
    /// <summary>
    /// 編輯產品主檔用的Dto
    /// </summary>
    public class UpdateProductMasterDto
    {
        /// <summary>
        /// 要編輯的id
        /// </summary>
        [JsonRequired]
        public long Id { get; set; }

        /// <summary>
        /// 產品主名稱
        /// </summary>
        [JsonRequired]
        [StringLength(50)]
        [NameValidation]
        public string Name { get; set; } = null!;

        /// <summary>
        /// 變種屬性
        /// </summary>
        /// <remarks>
        /// 這個產品變種屬性有哪一些值?
        /// ex: color:[red, blue], size[S,M]
        /// </remarks>
        public IEnumerable<VariantAttributeJson>? VariantAttributes { get; set; }

        /// <summary>
        /// 編輯者
        /// </summary>
        [JsonRequired]
        public string UpdateUser { get; set; } = null!;

        /// <summary>
        /// 編輯時間
        /// </summary>
        [JsonIgnore]
        public long UpdateDate { get; set; } = DateTime.UtcNow.GetUnixTimeMillisecond();

        /// <summary>
        /// 備註
        /// </summary>
        public string? Remarks { get; set; }

        /// <summary>
        /// 多國語系
        /// </summary>
        public IEnumerable<LanguageJson>? Languages { get; set; }

        /// <summary>
        /// 設定實體
        /// </summary>
        /// <param name="productMaster">要被修改的實體</param>
        /// <returns></returns>
        public ProductMaster SetEntity(ProductMaster productMaster) 
        {
            productMaster.Name = Name;
            productMaster.VariantAttribute = JsonSerializer.SerializeToDocument(VariantAttributes);
            productMaster.UpdateUser = UpdateUser;
            productMaster.UpdateDate = UpdateDate;
            productMaster.Remarks = Remarks;
            productMaster.Language = JsonSerializer.SerializeToDocument(Languages);

            return productMaster;
        }
    }
}
