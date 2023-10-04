using EShopAPI.Cores.ShopUsers;
using EShopCores.Extensions;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace EShopAPI.Cores.ShopRoles.DTOs
{
    /// <summary>
    /// 新增角色用的DTO
    /// </summary>
    public class InsertShopRoleDto
    {
        /// <summary>
        /// 角色代碼
        /// </summary>
        [JsonRequired]
        [StringLength(50)]
        public string Number { get; set; } = null!;

        /// <summary>
        /// 角色名稱
        /// </summary>
        [JsonRequired]
        [StringLength(50)]
        public string Name { get; set; } = null!;

        /// <summary>
        /// 是否啟用
        /// </summary>
        /// <remarks>
        /// 預設 = true
        /// </remarks>
        [JsonRequired]
        public bool IsEnable { get; set; } = true;

        /// <summary>
        /// 建立者
        /// </summary>
        [JsonRequired]
        public string CreateUser { get; set; } = null!;

        /// <summary>
        /// 建立時間
        /// </summary>
        [JsonIgnore]
        public long CreateDate { get; set; } = DateTime.UtcNow.GetUnixTimeMillisecond();

        /// <summary>
        /// 備註
        /// </summary>
        public string? Remarks { get; set; }

        /// <summary>
        /// 多國語系
        /// </summary>
        public Dictionary<string, string>? Language { get; set; }

        /// <summary>
        /// 轉成實體
        /// </summary>
        /// <returns></returns>
        public ShopRole ToEntity()
        {
            return new ShopRole
            {
                Number = Number,
                Name = Name,
                IsEnable = IsEnable,
                CreateUser = CreateUser,
                CreateDate = CreateDate,
                Remarks = Remarks,
                Language = System.Text.Json.JsonSerializer.SerializeToDocument(Language)
            };
        }
    }
}
