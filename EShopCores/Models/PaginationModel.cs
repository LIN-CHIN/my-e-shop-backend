using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShopCores.Models
{
    /// <summary>
    /// 分頁Model
    /// </summary>
    public class PaginationModel<T>
    {
        /// <summary>
        /// 回傳的物件清單
        /// </summary>
        public IQueryable<T>? Items { get; set; }

        /// <summary>
        /// 總數量
        /// </summary>
        public int TotalCount { get; set; }

        /// <summary>
        /// 總頁數
        /// </summary>
        public int TotalPage { get; set; }

    }
}
