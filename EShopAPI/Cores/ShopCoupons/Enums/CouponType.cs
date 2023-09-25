using System.ComponentModel;

namespace EShopAPI.Cores.ShopCoupons.Enums
{
    /// <summary>
    /// 優惠券類型
    /// </summary>
    public enum CouponType
    {
        /// <summary>
        /// 時間區間
        /// </summary>
        [Description("時間區間")]
        interval = 1,

        /// <summary>
        /// 特定日期
        /// </summary>
        [Description("特定日期")]
        SpecialDate = 2,

        /// <summary>
        /// 永久使用
        /// </summary>
        [Description("永久使用")]
        Forever = 3,

        /// <summary>
        /// 特定使用者
        /// </summary>
        [Description("特定使用者")]
        ForUser = 4,

    }
}
