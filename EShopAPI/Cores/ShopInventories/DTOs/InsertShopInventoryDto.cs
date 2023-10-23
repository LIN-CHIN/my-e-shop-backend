using EShopAPI.Validations;
using EShopCores.Enums;
using EShopCores.Extensions;
using EShopCores.Json;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace EShopAPI.Cores.ShopInventories.DTOs
{
    /// <summary>
    /// 新增商店庫存用的DTO
    /// </summary>
    public class InsertShopInventoryDto
    {
        /// <summary>
        /// 商品代碼
        /// </summary>
        [JsonRequired]
        [StringLength(50)]
        [NumberValidation]
        public string Number { get; set; } = null!;

        /// <summary>
        /// 商品名稱
        /// </summary>
        [JsonRequired]
        [StringLength(50)]
        [NameValidation]
        public string Name { get; set; } = null!;

        /// <summary>
        /// 商品庫存數量
        /// </summary>
        [JsonRequired]
        public int InventoryQuantity { get; set; }

        /// <summary>
        /// 商品庫存警告數
        /// </summary>
        [JsonRequired]
        public int InventoryAlert { get; set; }

        /// <summary>
        /// 供應商
        /// </summary>
        [StringLength(50)]
        public string? Supplier { get; set; }

        /// <summary>
        /// 品牌
        /// </summary>
        [StringLength(50)]
        public string? Brand { get; set; }

        /// <summary>
        /// 產品類型
        /// </summary>
        [JsonRequired]
        [EnumValidation]
        public ProductType ProductType { get; set; }

        /// <summary>
        /// 是否為組合產品
        /// </summary>
        [JsonRequired]
        public bool IsComposite { get; set; }

        /// <summary>
        /// 是否只能讓組合產品使用
        /// </summary>
        [JsonRequired]
        public bool IsCompositeOnly { get; set; }

        /// <summary>
        /// 是否啟用
        /// </summary>
        [JsonRequired]
        public bool IsEnable { get; set; }

        /// <summary>
        /// 變種屬性清單
        /// </summary>
        /// <remarks>
        /// 這個產品有哪個變種屬性? 值是是什麼
        /// ex: color: red, size: s
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
        /// <param name="userNumber">新增者帳號</param>
        /// <returns></returns>
        public ShopInventory ToEntity(string userNumber) 
        {
            return new ShopInventory
            {
                Number = Number,
                Name = Name,
                InventoryQuantity = InventoryQuantity,
                InventoryAlert = InventoryAlert,
                Supplier = Supplier,
                Brand = Brand,
                ProductType = ProductType,
                IsComposite = IsComposite,
                IsCompositeOnly = IsCompositeOnly,
                IsEnable = IsEnable,
                VariantAttribute =  JsonSerializer.SerializeToDocument(VariantAttributes),
                Remarks = Remarks ,
                Language = JsonSerializer.SerializeToDocument(Languages),
                CreateUser = userNumber,
                CreateDate = DateTime.UtcNow.GetUnixTimeMillisecond()
            };
        }
    }
}
