using EShopAPI.Cores.ShopRoles.DTOs;
using EShopCores.Errors;

namespace EShopAPI.Cores.ShopRoles.Services
{
    /// <summary>
    /// 商店角色 Service Interface
    /// </summary>
    public interface IShopRoleService
    {
        /// <summary>
        /// 取得角色清單
        /// </summary>
        /// <param name="queryDto">搜尋條件DTO</param>
        /// <returns></returns>
        IQueryable<ShopRole> Get(QueryShopRoleDto queryDto);

        /// <summary>
        /// 根據id取得角色
        /// </summary>
        /// <param name="id">角色id</param>
        /// <returns></returns>
        Task<ShopRole?> GetByIdAsync(long id);

        /// <summary>
        /// 根據id取得角色，但若找不到該id會直接throw exception
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="EShopException">找不到id</exception>
        Task<ShopRole> ThrowNotFindByIdAsync(long id);

        /// <summary>
        /// 新增角色
        /// </summary>
        /// <param name="insertDto">新增用的DTO</param>
        /// <returns></returns>
        Task<ShopRole> InsertAsync(InsertShopRoleDto insertDto);

        /// <summary>
        /// 編輯角色
        /// </summary>
        /// <param name="updateDto">編輯用的DTO</param>
        /// <returns></returns>
        Task UpdateAsync(UpdateShopRoleDto updateDto);

        /// <summary>
        /// 啟用/停用角色
        /// </summary>
        /// <param name="id">要啟用/停用的角色id</param>
        /// <param name="isEnable">
        /// true = 啟用
        /// false = 停用
        /// </param>
        /// <returns></returns>
        Task EnableAsync(long id, bool isEnable);
    }
}
