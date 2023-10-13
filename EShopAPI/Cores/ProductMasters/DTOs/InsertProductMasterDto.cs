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
    /// 新增產品主檔用的DTO
    /// </summary>
    public class InsertProductMasterDto
    {
        /// <summary>
        /// 產品主編號
        /// </summary>
        [JsonRequired]
        [StringLength(25)]
        [NumberValidation]
        public string Number { get; set; } = null!;

        /// <summary>
        /// 產品主名稱
        /// </summary>
        [JsonRequired]
        [StringLength(50)]
        [NameValidation]
        public string Name { get; set; } = null!;

        /// <summary>
        /// 產品類型
        /// </summary>
        [JsonRequired]
        [EnumValidation]
        public ProductType ProductType { get; set; }

        /// <summary>
        /// 是否啟用
        /// </summary>
        [JsonRequired]
        public bool IsEnable { get; set; }

        /// <summary>
        /// 變種屬性
        /// </summary>
        /// <remarks>
        /// 這個產品變種屬性有哪一些值?
        /// ex: color:[red, blue], size[S,M]
        /// </remarks>
        public IEnumerable<VariantAttributeJson>? VariantAttributes { get; set; }

        /// <summary>
        /// 備註
        /// </summary>
        public string? Remarks { get; set; }

        /// <summary>
        /// 多國語系
        /// </summary>
        public IEnumerable<LanguageJson>? Languages { get; set; }

        /// <summary>
        /// 轉成實體
        /// </summary>
        /// <param name="createUser">建立者</param>
        /// <returns></returns>
        public ProductMaster ToEntity(string createUser) 
        {
            return new ProductMaster
            {
                Number = Number,
                Name = Name,
                ProductType = ProductType,
                IsEnable = IsEnable,
                VariantAttribute = JsonSerializer.SerializeToDocument(VariantAttributes),
                CreateUser = createUser,
                CreateDate = DateTime.UtcNow.GetUnixTimeMillisecond(),
                Remarks = Remarks
            };
        }
    }
}
