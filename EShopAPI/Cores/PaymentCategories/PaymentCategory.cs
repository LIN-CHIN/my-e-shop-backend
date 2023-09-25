using EShopAPI.Cores.OrderMasters;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EShopAPI.Cores.PaymentCategories
{
    /// <summary>
    /// 支付類型實體
    /// </summary>
    [Table("payment_category", Schema = "eshop")]
    [Comment("支付類型實體")]
    public class PaymentCategory : EShopObject
    {
        /// <summary>
        /// 支付類型代碼
        /// </summary>
        [Required]
        [Column("number", TypeName = "varchar(50)")]
        [Comment("支付類型代碼")]
        [StringLength(50)]
        public string Number { get; set; } = null!;

        /// <summary>
        /// 支付類型名稱
        /// </summary>
        [Required]
        [Column("name", TypeName = "varchar(50)")]
        [Comment("支付類型名稱")]
        [StringLength(50)]
        public string Name { get; set; } = null!;

        /// <summary>
        /// 使用者偏好實體清單
        /// </summary>
        public ICollection<OrderMaster>? OrderMasters { get; set; }
    }
}
