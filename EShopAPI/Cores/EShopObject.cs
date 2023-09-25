using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;

namespace EShopAPI.Cores
{
    /// <summary>
    /// EShop 基底物件
    /// </summary>
    public abstract class EShopObject
    {
        /// <summary>
        /// 系統id
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id", Order = 0)]
        [Comment("系統id")]
        public long Id { get; set; }

        /// <summary>
        /// 建立者
        /// </summary>
        [Required]
        [Column("create_user", TypeName = "varchar(50)")]
        [Comment("建立者")]
        public string CreateUser { get; set; } = null!;

        /// <summary>
        /// 建立時間
        /// </summary>
        [Required]
        [Column("create_date")]
        [Comment("建立日期")]
        public long CreateDate { get; set; } 

        /// <summary>
        /// 更新者
        /// </summary>
        [Column("update_user", TypeName = "varchar(50)")]
        [Comment("更新者")]
        public string? UpdateUser { get; set; }

        /// <summary>
        /// 修改時間
        /// </summary>
        [Column("update_date")]
        [Comment("更新日期")]
        public long? UpdateDate { get; set; }

        /// <summary>
        /// 備註
        /// </summary>
        [Column("remarks", TypeName = "text")]
        [Comment("備註")]
        public string? Remarks
        {
            get; set;
        }

        /// <summary>
        /// 多國語系
        /// </summary>
        [Column("language", TypeName = "jsonb")]
        [Comment("多國語系")]
        public JsonDocument? Language { get; set; }
    }
}
