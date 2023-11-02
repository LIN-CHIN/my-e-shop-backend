namespace EShopAPI.Cores.EShopUnits.DTOs
{
    /// <summary>
    /// 回傳商店單位回的結果
    /// </summary>
    public class EShopUnitDto : EShopObjectDto
    {
        /// <summary>
        /// 單位代碼
        /// </summary>
        public string Number { get; set; } = null!;

        /// <summary>
        /// 單位名稱
        /// </summary>
        public string Name { get; set; } = null!;

        /// <summary>
        /// 是否啟用
        /// </summary>
        public bool IsEnable { get; set; }

        /// <summary>
        /// 是否為系統預設
        /// </summary>
        public bool IsSystemDefault { get; set; }

        /// <summary>
        /// 將實體解析成DTO
        /// </summary>
        /// <param name="eShopUnit">商店單位的實體</param>
        /// <returns></returns>
        public static EShopUnitDto? Parse(EShopUnit? eShopUnit) 
        {
            if (eShopUnit == null) 
            {
                return null;
            }

            EShopUnitDto eShopUnitDto = new EShopUnitDto
            {
                Number = eShopUnit.Number,
                Name = eShopUnit.Name,
                IsEnable = eShopUnit.IsEnable,
                IsSystemDefault = eShopUnit.IsSystemDefault
            };

            eShopUnitDto.ParseBaseObject(eShopUnit);

            return eShopUnitDto;
        }
    }
}
