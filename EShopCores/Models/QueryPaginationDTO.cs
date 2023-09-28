using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShopCores.Models
{
    /// <summary>
    /// 分頁查詢用的DTO
    /// </summary>
    public class QueryPaginationDTO
    {
        /// <summary>
        /// 使用者要取得第幾頁的資料
        /// </summary>
        public int Page { get; set; } = 1;

        /// <summary>
        /// 使用者一頁要取幾筆資料
        /// </summary>
        public int PageCount { get; set; } = 200;
    }
}
