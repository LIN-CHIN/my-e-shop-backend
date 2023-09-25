using EShopAPI.Cores.ShopCoupons.Enums;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EShopAPI.Cores.ShopCoupons
{
    /// <summary>
    /// 商店優惠券
    /// </summary>
    [Table("shop_coupon", Schema = "eshop")]
    [Comment("商店優惠券")]
    public class ShopCoupon : EShopObject
    {
        /// <summary>
        /// 角色代碼
        /// </summary>
        [Required]
        [Column("number", TypeName = "varchar(50)")]
        [Comment("角色代碼")]
        [StringLength(50)]
        public string Number { get; set; } = null!;

        /// <summary>
        /// 使用者名稱
        /// </summary>
        [Required]
        [Column("name", TypeName = "varchar(50)")]
        [Comment("角色名稱")]
        [StringLength(50)]
        public string Name { get; set; } = null!;

        /// <summary>
        /// 優惠券類型
        /// </summary>
        [Required]
        [Column("coupon_type")]
        [Comment("優惠券類型")]
        public CouponType CouponType { get; set; }

        /// <summary>
        /// 有效期限(起)
        /// </summary>
        [Column("use_start_date")]
        [Comment("有效期限(起)")]
        public long? UseStartDate { get; set; }

        /// <summary>
        /// 有效期限(迄)
        /// </summary>
        [Column("use_end_date")]
        [Comment("有效期限(起)")]
        public long? UseEndDate { get; set; }

        /// <summary>
        /// 是否啟用
        /// </summary>
        [Required]
        [Column("is_enable")]
        [Comment("是否啟用")]
        public bool IsEnable { get; set; }
    }
}
