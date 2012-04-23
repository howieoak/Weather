using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using System.Collections;

namespace Weather.Model.Common
{
    /// <summary>
    /// These are model extension methods.
    /// Working on model and plain clr objects.
    /// </summary>
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="arg"></param>
        /// <returns></returns>
        public static double ToRad(this double arg)
        {
            return arg * Math.PI / 180;
        }
    }
}
