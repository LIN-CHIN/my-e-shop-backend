using EShopAPI.Cores.ProductMasters.Json;
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
        public string Number { get; set; } = null!;

        /// <summary>
        /// 產品主名稱
        /// </summary>
        [JsonRequired]
        [StringLength(50)]
        public string Name { get; set; } = null!;

        /// <summary>
        /// 產品類型
        /// </summary>
        [JsonRequired]
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
        /// 建立者
        /// </summary>
        [JsonRequired]
        public string CreateUser { get; set; } = null!;

        /// <summary>
        /// 建立時間
        /// </summary>
        [JsonRequired]
        public long CreateDate { get; set; } = DateTime.UtcNow.GetUnixTimeMillisecond();

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
        /// <returns></returns>
        public ProductMaster ToEntity() 
        {
            return new ProductMaster
            {
                Number = Number,
                Name = Name,
                ProductType = ProductType,
                IsEnable = IsEnable,
                VariantAttribute = JsonSerializer.SerializeToDocument(VariantAttributes),
                CreateUser = CreateUser,
                CreateDate = CreateDate,
                Remarks = Remarks
            };
        }
    }
}
