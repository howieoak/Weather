using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;

namespace Weather.Model.Common
{
    public static class ExtensionMethods
    {
        public static string ToStringPeriod(this double arg)
        {
            //return arg.ToString("0.00", CultureInfo.InvariantCulture);
            //string.Format("{0:C}", arg);
            NumberFormatInfo nfi = new NumberFormatInfo();
            nfi.NumberDecimalSeparator = ".";
            return arg.ToString(nfi); 

        }

    }
}
