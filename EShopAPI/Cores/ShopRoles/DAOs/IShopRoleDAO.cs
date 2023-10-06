using EShopAPI.Cores.ShopRoles.DTOs;
using EShopCores.Errors;

namespace EShopAPI.Cores.ShopRoles.DAOs
{
    /// <summary>
    /// 商店角色的 DAO Interface
    /// </summary>
    public interface IShopRoleDao
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
        /// <param name="id"></param>
        /// <returns></returns>
        Task<ShopRole?> GetByIdAsync(long id);

        /// <summary>
        /// 根據number取得角色
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        Task<ShopRole?> GetByNumberAsync(string number);

        /// <summary>
        /// 新增角色
        /// </summary>
        /// <param name="shopRole">要新增的角色實體</param>
        /// <returns></returns>
        Task<ShopRole> InsertAsync(ShopRole shopRole);

        /// <summary>
        /// 編輯角色
        /// </summary>
        /// <param name="shopRole">要編輯的角色實體</param>
        /// <returns></returns>
        Task UpdateAsync(ShopRole shopRole);
    }
}
