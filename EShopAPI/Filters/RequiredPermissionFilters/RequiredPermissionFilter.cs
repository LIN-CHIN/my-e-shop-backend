using EShopAPI.Common.Enums;
using Microsoft.AspNetCore.Mvc;

namespace EShopAPI.Filters.RequiredPermissionFilters
{
    /// <summary>
    /// 驗證User是否有權限
    /// </summary>
    public class RequiredPermissionFilter : TypeFilterAttribute
    {
        /// <summary>
        /// RequiredPermissionFilter Constructor
        /// </summary>
        /// <param name="type"></param>
        /// <param name="cruds"></param>
        public RequiredPermissionFilter(ShopPermissionType type, params HttpMethodType[] cruds) : base(typeof(RequiredPermissionBaseFilter))
        {
            Arguments = new object[] { type, cruds };
        }
    }
}
