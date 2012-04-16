using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Weather.Model.Common
{
    public static class Helpers
    {
        /// <summary>
        /// Converts the var symbol, if it starts with mf.
        /// Example: mf/03n.83 is converted to 03n
        /// </summary>
        /// <param name="var"></param>
        /// <returns></returns>
        public static string ParseSymbolVar(string var)
        {
            string fileName;

            if (var.StartsWith("mf"))
            {
                //fileName = var.TrimStart("mf/".ToCharArray()).TrimEnd(".83".ToCharArray());
                fileName = new string(var.Skip(3).Take(3).ToArray());
            }
            else
            {
                fileName = var;
            }

            return fileName;
        }
    }
}
