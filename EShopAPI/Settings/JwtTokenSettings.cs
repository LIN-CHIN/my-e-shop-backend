namespace EShopAPI.Settings
{
    /// <summary>
    /// JWT 設定
    /// </summary>
    public class JwtTokenSettings
    {
        /// <summary>
        /// 發行者
        /// </summary>
        public string Issuer { get; private set; } = null!;

        /// <summary>
        /// 簽證key
        /// </summary>
        public string SignKey { get; private set; } = null!;
    }
}
