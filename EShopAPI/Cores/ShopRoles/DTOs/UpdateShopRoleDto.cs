using EShopCores.Extensions;
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
        public string Name { get; set; } = null!;

        /// <summary>
        /// 編輯者
        /// </summary>
        [JsonRequired]
        public string UpdateUser { get; set; } = null!;

        /// <summary>
        /// 建立時間
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
        public Dictionary<string, string>? Language { get; set; }

        /// <summary>
        /// 設定要修改的實體內容
        /// </summary>
        /// <param name="shopRole">要被修改的實體</param>
        /// <returns></returns>
        public ShopRole SetEntity(ShopRole shopRole) 
        {
            shopRole.Id = Id;
            shopRole.Name = Name;
            shopRole.UpdateUser = UpdateUser;
            shopRole.UpdateDate = UpdateDate;
            shopRole.Remarks = Remarks;
            shopRole.Language = JsonSerializer.SerializeToDocument(Language);
            return shopRole;
        }
    }
}
