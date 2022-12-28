using System;
using System.Globalization;

namespace OkexMapper.Extensions
{
    public static class DecimalExtensions
    {
        private static readonly NumberFormatInfo NumberFormat = new NumberFormatInfo { NumberDecimalSeparator = @"." };

        public static string ToFormattedString(this decimal value) => value.ToString(NumberFormat);

        public static decimal ToDecimal(this string value)
        {
            try 
            {
                return decimal.Parse(value.Replace(".", ","));
            }
            catch
            {
                return 0;
            }
        }
    }
}
