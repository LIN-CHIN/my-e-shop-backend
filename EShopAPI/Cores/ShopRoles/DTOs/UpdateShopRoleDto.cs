using EShopAPI.Validations;
using EShopCores.Extensions;
using EShopCores.Json;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace EShopAPI.Cores.ShopRoles.DTOs
{
    /// <summary>
    /// 編輯角色用的DTO
    /// </summary>
    public class UpdateShopRoleDto
    {
        /// <summary>
        /// 角色id
        /// </summary>
        [JsonRequired]
        public long Id { get; set; }

        /// <summary>
        /// 角色名稱
        /// </summary>
        [JsonRequired]
        [StringLength(50)]
        [NameValidation]
        public string Name { get; set; } = null!;

        /// <summary>
        /// 備註
        /// </summary>
        public string? Remarks { get; set; }

        /// <summary>
        /// 多國語系
        /// </summary>
        public IEnumerable<LanguageJson>? Languages { get; set; }

        /// <summary>
        /// 設定要修改的實體內容
        /// </summary>
        /// <param name="shopRole">要被修改的實體</param>
        /// <param name="userNumber">修改者的帳號</param>
        /// <returns></returns>
        public ShopRole SetEntity(ShopRole shopRole, string userNumber) 
        {
            shopRole.Id = Id;
            shopRole.Name = Name;
            shopRole.UpdateUser = userNumber;
            shopRole.UpdateDate = DateTime.UtcNow.GetUnixTimeMillisecond();
            shopRole.Remarks = Remarks;
            shopRole.Language = JsonSerializer.SerializeToDocument(Languages);
            return shopRole;
        }
    }
}
