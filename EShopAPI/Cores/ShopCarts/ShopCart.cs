using EShopAPI.Cores.ShopUsers;
using EShopCores.Enums;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EShopAPI.Cores.ShopCarts
{
    /// <summary>
    /// 購物車實體
    /// </summary>
    [Table("shop_cart", Schema = "eshop")]
    [Comment("購物車實體")]
    public class ShopCart : EShopObject
    {
        /// <summary>
        /// 使用者id
        /// </summary>
        [Required]
        [Column("user_id")]
        [Comment("使用者id")]
        public long UserId { get; set; }

        /// <summary>
        /// 產品實體類型
        /// </summary>
        [Required]
        [Column("product_entity_type")]
        [Comment("產品實體類型")]
        public ProductEntityType ProductEntityType { get; set; }

        /// <summary>
        /// 物件id (根據ProductEntityType不同而對應的實體id)
        /// </summary>
        [Required]
        [Column("object_id")]
        [Comment("物件id (根據ProductEntityType不同而對應的實體id)")]
        public long ObjectId { get; set; }

        /// <summary>
        /// 數量
        /// </summary>
        [Required]
        [Column("count")]
        [Comment("數量")]
        public int Count { get; set; }

        /// <summary>
        /// 使用者實體
        /// </summary>
        public ShopUser? ShopUser { get; set; }
    }
}
