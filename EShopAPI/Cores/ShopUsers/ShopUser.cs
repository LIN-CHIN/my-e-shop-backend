using EShopAPI.Cores.DeliveryPreferences;
using EShopAPI.Cores.MapUserRoles;
using EShopAPI.Cores.OrderMasters;
using EShopAPI.Cores.RecordOrderMasters;
using EShopAPI.Cores.ShopCarts;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EShopAPI.Cores.ShopUsers
{
    /// <summary>
    /// 商店使用者實體
    /// </summary>
    [Table("shop_user", Schema = "eshop")]
    [Comment("商店使用者實體")]
    public class ShopUser : EShopObject
    {
        /// <summary>
        /// 使用者代碼/帳號
        /// </summary>
        [Required]
        [Column("number", TypeName = "varchar(50)")]
        [Comment("使用者代碼/帳號")]
        [StringLength(50)]
        public string Number { get; set; } = null!;

        /// <summary>
        /// 使用者名稱
        /// </summary>
        [Required]
        [Column("name", TypeName = "varchar(50)")]
        [Comment("使用者名稱")]
        [StringLength(50)]
        public string Name { get; set; } = null!;

        /// <summary>
        /// 密碼
        /// </summary>
        [Required]
        [Column("pwd", TypeName = "text")]
        [Comment("密碼")]
        public string Pwd { get; set; } = null!;

        /// <summary>
        /// 地址
        /// </summary>
        [Column("address", TypeName = "varchar(100)")]
        [Comment("地址")]
        [StringLength(100)]
        public string? Address { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        [Column("email", TypeName = "varchar(50)")]
        [Comment("Email")]
        [StringLength(50)]
        public string? Email { get; set; }

        /// <summary>
        /// 手機
        /// </summary>
        [Column("phone", TypeName = "varchar(20)")]
        [Comment("手機")]
        [StringLength(20)]
        public string? Phone { get; set; }

        /// <summary>
        /// 是否啟用
        /// </summary>
        [JsonRequired]
        [Column("is_enable")]
        [Comment("是否啟用")]
        public bool IsEnable { get; set; }

        /// <summary>
        /// 使用者與角色的關聯
        /// </summary>
        public ICollection<MapUserRole>? MapUserRoles { get; set; }

        /// <summary>
        /// 購物車實體清單
        /// </summary>
        public ICollection<ShopCart>? ShopCarts { get; set; }

        /// <summary>
        /// 物流偏好實體清單
        /// </summary>
        public ICollection<DeliveryPreference>? DeliveryPreferences { get; set; }

        /// <summary>
        /// 使用者偏好實體清單
        /// </summary>
        public ICollection<OrderMaster>? OrderMasters { get; set; }

        /// <summary>
        /// 訂單主檔紀錄實體清單
        /// </summary>
        public ICollection<RecordOrderMaster>? RecordOrderMasters { get; set; }
    }
}
