using EShopAPI.Validations;
using EShopCores.Enums;
using EShopCores.Extensions;
using EShopCores.Json;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Xml.Linq;

namespace EShopAPI.Cores.ShopInventories.DTOs
{
    /// <summary>
    /// 編輯商店庫存用的DTO
    /// </summary>
    public class UpdateShopInventoryDto
    {
        /// <summary>
        /// 要編輯的商店庫存id
        /// </summary>
        [JsonRequired]
        public long Id { get; set; }

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
        /// 備註
        /// </summary>
        public string? Remarks { get; set; }

        /// <summary>
        /// 多國語系
        /// </summary>
        public IEnumerable<LanguageJson>? Languages { get; set; }

        /// <summary>
        /// 設定要update的實體
        /// </summary>
        /// <param name="shopInventory">根據id取出的實體(要被編輯的)</param>
        /// <param name="userNumber">修改者帳號</param>
        /// <returns></returns>
        public ShopInventory SetEntity(ShopInventory shopInventory, string userNumber) 
        {
            shopInventory.Name = Name;
            shopInventory.InventoryQuantity = InventoryQuantity; 
            shopInventory.InventoryAlert = InventoryAlert; 
            shopInventory.Supplier = Supplier; 
            shopInventory.Brand = Brand; 
            shopInventory.Remarks = Remarks;
            shopInventory.Language = JsonSerializer.SerializeToDocument(Languages);
            shopInventory.UpdateUser = userNumber;
            shopInventory.UpdateDate = DateTime.UtcNow.GetUnixTimeMillisecond();

            return shopInventory;
        }
    }
}
