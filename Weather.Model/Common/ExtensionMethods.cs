using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;

namespace Weather.Model.Common
{
    public static class ExtensionMethods
    {
        /// <summary>
        /// Converts the double (with a comma) to a string (with period)
        /// </summary>
        /// <param name="arg"></param>
        /// <returns></returns>
        public static string ToStringPeriod(this double arg)
        {
            NumberFormatInfo nfi = new NumberFormatInfo();
            nfi.NumberDecimalSeparator = ".";
            return arg.ToString(nfi); 
        }

        /// <summary>
        /// Converts the string (with a period) to a double (with comma).
        /// </summary>
        /// <param name="arg"></param>
        /// <returns></returns>
        public static double ToDoubleComma(this string arg)
        {
            NumberFormatInfo nfi = new NumberFormatInfo();
            nfi.NumberDecimalSeparator = ".";
            return Double.Parse(arg, nfi);

        }

    }
}
