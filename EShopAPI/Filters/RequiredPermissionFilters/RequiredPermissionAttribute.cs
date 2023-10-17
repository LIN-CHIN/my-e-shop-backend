using EShopAPI.Common.Enums;
using Microsoft.AspNetCore.Mvc;

namespace EShopAPI.Filters.RequiredPermissionFilters
{
    /// <summary>
    /// 驗證User是否有權限
    /// </summary>
    public class RequiredPermissionAttribute : TypeFilterAttribute
    {
        /// <summary>
        /// RequiredPermissionFilter Constructor
        /// </summary>
        /// <param name="type"></param>
        /// <param name="cruds"></param>
        public RequiredPermissionAttribute(ShopPermissionType type, params HttpMethodType[] cruds) : base(typeof(RequiredPermissionBaseAttribute))
        {
            Arguments = new object[] { type, cruds };
        }
    }
}
