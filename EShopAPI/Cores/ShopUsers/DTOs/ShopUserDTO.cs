using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EShopAPI.Cores.ShopUsers.DTOs
{
    /// <summary>
    /// 查詢使用者回傳的DTO
    /// </summary>
    public class ShopUserDTO : EShopObjectDTO
    {
        /// <summary>
        /// 使用者代碼/帳號
        /// </summary>
        public string Number { get; set; } = null!;

        /// <summary>
        /// 使用者名稱
        /// </summary>
        public string Name { get; set; } = null!;

        /// <summary>
        /// 地址
        /// </summary>
        public string? Address { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        public string? Email { get; set; }

        /// <summary>
        /// 手機
        /// </summary>
        public string? Phone { get; set; }

        /// <summary>
        /// 是否啟用
        /// </summary>
        public bool IsEnable { get; set; }

        /// <summary>
        /// 將實體解析成ShopUserDTO
        /// </summary>
        /// <param name="shopUser"></param>
        /// <returns></returns>
        public static ShopUserDTO? Parse(ShopUser? shopUser) 
        {
            if (shopUser == null) 
            {
                return null;
            }

            ShopUserDTO shopUserDTO = new ShopUserDTO
            {
                Number = shopUser.Number,
                Name = shopUser.Name,
                Address = shopUser.Address,
                Email = shopUser.Email,
                Phone = shopUser.Phone,
                IsEnable = shopUser.IsEnable
            };

            shopUserDTO.ParseBaseObject(shopUser);
            return shopUserDTO;
        }
    }
}
