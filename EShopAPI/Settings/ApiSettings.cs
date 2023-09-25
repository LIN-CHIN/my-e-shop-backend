namespace EShopAPI.Settings
{
    /// <summary>
    /// Api設定
    /// </summary>
    public class ApiSettings
    {
        /// <summary>
        /// DB連線字串
        /// </summary>
        public string ConnectionString { get; private set; } = null!;
    }
}
