using EShopCores.Errors;
using EShopCores.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShopCores.Responses
{
    /// <summary>
    /// 回傳分頁訊息的物件
    /// </summary>
    public class PaginationResponse<T> : BaseResponse
    {
        /// <summary>
        /// 回傳內容
        /// </summary>
        [JsonProperty(Order = 3)]
        public PaginationModel<T>? Content { get; set; }

        /// <summary>
        /// 回傳結果
        /// </summary>
        /// <param name="page">使用者要取得第幾頁的資料</param>
        /// <param name="pageCount">使用者一頁要取幾筆資料</param>
        /// <param name="content">資料清單</param>
        /// <returns></returns>
        public static PaginationResponse<T> GetSuccess(int page, int pageCount, IQueryable<T> content) 
        {
            CheckPageParameters(page, pageCount);

            var items = content.Skip((page - 1) * pageCount).Take(pageCount);
            int totalCount = content.Count();
            int totalPage = CountingTotalPage(totalCount, pageCount);

            return new PaginationResponse<T>
            {
                Code = ResponseCodeType.Success,
                Message = ResponseCodeType.Success.GetMessage(),
                Description = ResponseCodeType.Success.GetDescription(),
                Content = new PaginationModel<T>
                {
                    Items = items,
                    TotalCount = totalCount,
                    TotalPage = totalPage
                }
            };
        }

        /// <summary>
        /// 檢查分頁參數
        /// </summary>
        /// <returns></returns>
        private static void CheckPageParameters(int page, int pageCount) 
        {
            if (page < 1) 
            {
                throw new EShopException(
                    ResponseCodeType.RequestParameterError,
                    "page 不可小於1");
            }

            if (pageCount < 1)
            {
                throw new EShopException(
                    ResponseCodeType.RequestParameterError,
                    "pageCount 不可小於1");
            }
        }

        /// <summary>
        /// 計算總頁數
        /// </summary>
        /// <param name="listCount">資料總數量</param>
        /// <param name="pageCount">每頁顯示多少資料</param>
        /// <returns></returns>
        public static int CountingTotalPage(int listCount, int pageCount)
        {
            if (listCount % pageCount != 0)
            {
                return (listCount / pageCount) + 1;
            }
            else
            {
                return listCount / pageCount;
            }
        }
    }
}
