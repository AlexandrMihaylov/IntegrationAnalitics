using System;

namespace IntegrationAnalitics.Application.Extensions
{
    public static class UnixTimeExtensions
    {
        
        public static long ToUnixTimeSeconds(this DateTime value) =>
            (long)(value - unix_epoch).TotalSeconds;

        static DateTime unix_epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        
        public static long ToUnixTimeMilliseconds(this DateTime value) =>
            (long)(value - unix_epoch).TotalMilliseconds;

        public static DateTime ToDateTimeFromUnixTimeMilliseconds(this long value) =>
            DateTimeOffset.FromUnixTimeMilliseconds(value).DateTime;

        public static string ToOSI8601(this DateTime dateTime) => dateTime.ToString("yyyy-MM-ddTHH:mm:ssZ");
    }
}