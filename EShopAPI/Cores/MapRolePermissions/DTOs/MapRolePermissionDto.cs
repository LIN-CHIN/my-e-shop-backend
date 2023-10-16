using EShopAPI.Cores.ShopPermissions.DTOs;
using EShopAPI.Cores.ShopRoles.DTOs;

namespace EShopAPI.Cores.MapRolePermissions.DTOs
{
    /// <summary>
    /// 角色與權限的DTO
    /// </summary>
    public class MapRolePermissionDto : EShopObjectDto
    {
        /// <summary>
        /// 角色id
        /// </summary>
        public long RoleId { get; set; }

        /// <summary>
        /// 權限id
        /// </summary>
        public long PermissionId { get; set; }

        /// <summary>
        /// 是否有新增的權限
        /// </summary>
        public bool IsCreatePermission { get; set; }

        /// <summary>
        /// 是否有讀取的權限
        /// </summary>
        public bool IsReadPermission { get; set; }

        /// <summary>
        /// 是否有編輯的權限
        /// </summary>
        public bool IsUpdatePermission { get; set; }

        /// <summary>
        /// 是否有刪除的權限
        /// </summary>
        public bool IsDeletePermission { get; set; }

        /// <summary>
        /// 商店角色DTO
        /// </summary>
        public ShopRoleDto ShopRole { get; set; } = null!;

        /// <summary>
        /// 商店權限DTO
        /// </summary>
        public ShopPermissionDto ShopPermission { get; set; } = null!;

        /// <summary>
        /// 將實體解析成 MapRolePermissionDto
        /// </summary>
        /// <param name="mapRolePermission">角色與權限關聯的實體</param>
        /// <returns></returns>
        public static MapRolePermissionDto? Parse(MapRolePermission? mapRolePermission)
        {
            if (mapRolePermission == null)
            {
                return null;
            }

            MapRolePermissionDto mapRolePermissionDto = new MapRolePermissionDto
            {
                RoleId = mapRolePermission.RoleId,
                PermissionId = mapRolePermission.PermissionId,
                IsCreatePermission = mapRolePermission.IsCreatePermission,
                IsReadPermission = mapRolePermission.IsReadPermission,
                IsUpdatePermission = mapRolePermission.IsUpdatePermission,
                IsDeletePermission = mapRolePermission.IsDeletePermission,
                ShopRole = ShopRoleDto.Parse(mapRolePermission.ShopRole)!,
                ShopPermission = ShopPermissionDto.Parse(mapRolePermission.ShopPermission)!,
            };

            mapRolePermissionDto.ParseBaseObject(mapRolePermission);
            return mapRolePermissionDto;
        }
    }
}
