using EShopAPI.Common.Enums;
using EShopAPI.Filters.RequiredPermissionFilters;
using Microsoft.AspNetCore.Mvc;

namespace EShopAPI.Filters.RequiredAdminFilters
{
    /// <summary>
    /// 必須具備Admin的權限
    /// </summary>
    public class RequiredAdminAttribute : TypeFilterAttribute
    {
        /// <summary>
        /// RequiredAdminFilter Constructor
        /// </summary>
        public RequiredAdminAttribute() : base(typeof(RequiredAdminBaseAttribute))
        {
        }
    }
}
