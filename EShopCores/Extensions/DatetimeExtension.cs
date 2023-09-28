namespace EShopCores.Extensions
{
    public static class DatetimeExtension
    {
        /// <summary>
        /// 取UnixTimestamp(毫秒)
        /// </summary>
        /// <param name="datetime"></param>
        /// <returns></returns>
        public static long GetUnixTimeMillisecond(this DateTime datetime) 
        {
            DateTimeOffset dateTimeOffset = new DateTimeOffset(datetime);
            return dateTimeOffset.ToUnixTimeMilliseconds();
        }

        /// <summary>
        /// 取得UnixTimestamp(秒)
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static long GetUnixTimestampSecond(this DateTime dateTime)
        {
            DateTimeOffset dateTimeOffset = new DateTimeOffset(dateTime);
            return dateTimeOffset.ToUnixTimeSeconds();
        }
    }
}
