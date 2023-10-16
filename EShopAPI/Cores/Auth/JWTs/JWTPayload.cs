using EShopAPI.Common;
using EShopAPI.Cores.MapRolePermissions.DTOs;

namespace EShopAPI.Cores.Auth.JWTs
{
    /// <summary>
    /// JWT payload
    /// </summary>
    public class JwtPayload : JwtBasePayload
    {
        /// <summary>
        /// 是否為管理員
        /// </summary>
        public bool IsAdmin { get; set; }

        /// <summary>
        /// 權限清單
        /// </summary>
        public IList<MapRolePermissionDto?>? MapRolePermissions { get; set; }

        /// <summary>
        /// 設定登入者資料
        /// </summary>
        /// <param name="loginUserData">要設定資料的實體</param>
        /// <returns></returns>
        public void SetLoginUserData(LoginUserData loginUserData) 
        {
            loginUserData.UserNumber = Subject;
            loginUserData.IsAdmin = IsAdmin;
            loginUserData.MapRolePermissions = MapRolePermissions;
        }
    }
}
