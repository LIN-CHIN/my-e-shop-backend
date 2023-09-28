using System.Text.Json;

namespace EShopAPI.Cores
{
    /// <summary>
    /// 共同回傳的物件DTO
    /// </summary>
    public abstract class EShopObjectDTO
    {
        /// <summary>
        /// 系統id
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// 建立者
        /// </summary>
        public string CreateUser { get; set; } = null!;

        /// <summary>
        /// 建立時間
        /// </summary>
        public long CreateDate { get; set; }

        /// <summary>
        /// 更新者
        /// </summary>
        public string? UpdateUser { get; set; }

        /// <summary>
        /// 修改時間
        /// </summary>
        public long? UpdateDate { get; set; }

        /// <summary>
        /// 備註
        /// </summary>
        public string? Remarks { get; set; }

        /// <summary>
        /// 多國語系
        /// </summary>
        public JsonDocument? Language { get; set; }

        /// <summary>
        /// 解析成EShopObjectDTO
        /// </summary>
        /// <param name="eShopObject"></param>
        /// <returns></returns>
        protected void ParseBaseObject(EShopObject eShopObject) 
        {
            Id = eShopObject.Id;
            CreateUser = eShopObject.CreateUser;
            CreateDate = eShopObject.CreateDate;
            UpdateUser = eShopObject.UpdateUser;
            UpdateDate = eShopObject.UpdateDate;
            Remarks = eShopObject.Remarks;
            Language = eShopObject.Language;
        }
    }
}
