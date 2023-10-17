using EShopAPI.Common.Enums;
using EShopAPI.Filters.RequiredPermissionFilters;
using Microsoft.AspNetCore.Mvc;

namespace EShopAPI.Filters.RequiredAdminFilters
{
    /// <summary>
    /// 必須具備Admin的權限
    /// </summary>
    public class RequiredAdminFilter : TypeFilterAttribute
    {
        /// <summary>
        /// RequiredAdminFilter Constructor
        /// </summary>
        public RequiredAdminFilter() : base(typeof(RequiredAdminBaseFilter))
        {
        }
    }
}
