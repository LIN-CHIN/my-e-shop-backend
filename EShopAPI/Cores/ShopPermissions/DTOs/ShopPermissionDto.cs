namespace EShopAPI.Cores.ShopPermissions.DTOs
{
    /// <summary>
    /// 商店權限DTO (回傳查詢結果)
    /// </summary>
    public class ShopPermissionDto : EShopObjectDto
    {
        /// <summary>
        /// 權限代碼
        /// </summary>
        public string Number { get; set; } = null!;
        /// <summary>
        /// 權限名稱
        /// </summary>
        public string Name { get; set; } = null!;
        /// <summary>
        /// 是否啟用
        /// </summary>
        public bool IsEnable { get; set; }

        /// <summary>
        /// 將實體解析成 ShopPermissionDto
        /// </summary>
        /// <param name="shopPermission"></param>
        /// <returns></returns>
        public static ShopPermissionDto? Parse(ShopPermission? shopPermission)
        {
            if (shopPermission == null)
            {
                return null;
            }

            ShopPermissionDto shopPermissionDto = new ShopPermissionDto
            {
                Number = shopPermission.Number,
                Name = shopPermission.Name,
                IsEnable = shopPermission.IsEnable
            };

            shopPermissionDto.ParseBaseObject(shopPermission);
            return shopPermissionDto;
        }
    }
}
