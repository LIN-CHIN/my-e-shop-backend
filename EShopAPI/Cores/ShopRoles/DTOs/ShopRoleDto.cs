using EShopAPI.Cores.ShopUsers.DTOs;
using EShopAPI.Cores.ShopUsers;

namespace EShopAPI.Cores.ShopRoles.DTOs
{
    /// <summary>
    /// 回傳商店角色用的DTO
    /// </summary>
    public class ShopRoleDto : EShopObjectDto
    {
        /// <summary>
        /// 角色代碼
        /// </summary>
        public string Number { get; set; } = null!;

        /// <summary>
        /// 角色名稱
        /// </summary>
        public string Name { get; set; } = null!;

        /// <summary>
        /// 是否啟用
        /// </summary>
        public bool IsEnable { get; set; }

        /// <summary>
        /// 將實體解析成ShopUserDTO
        /// </summary>
        /// <param name="shopRole"></param>
        /// <returns></returns>
        public static ShopRoleDto? Parse(ShopRole? shopRole)
        {
            if (shopRole == null)
            {
                return null;
            }

            ShopRoleDto shopRoleDto = new ShopRoleDto
            {
                Number = shopRole.Number,
                Name = shopRole.Name,
                IsEnable = shopRole.IsEnable
            };

            shopRoleDto.ParseBaseObject(shopRole);
            return shopRoleDto;
        }
    }
}
