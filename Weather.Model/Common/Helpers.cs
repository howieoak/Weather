using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Weather.Model.Common
{
    public static class Helpers
    {
        /// <summary>
        /// Returns the path to the image (url).
        /// The path returned is depended if the smaller or the bigger image is wanted.
        /// </summary>
        /// <param name="var">This string contains the file name,</param>
        /// <param name="sizeBig">If true, the big image is returned else the smaal image is returned.</param>
        /// <returns>The url to the image.</returns>
        public static string WeatherImageUrl(string var, bool sizeBig)
        {
            if (sizeBig)
                return string.Format("/Content/images/yr-icons/icons_120x100/{0}.png", ParseSymbolVar(var));
            else
                return string.Format("/Content/images/yr-icons/icons_60x50/{0}.png", ParseSymbolVar(var));
        }
        
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

        public static double CalculateDistance(double startLat, double startLon, double destLat, double destLon)
        {
            double R = 6371; //km
            double dLat = (destLat - startLat).ToRad();
            double dLon = (destLon - startLon).ToRad();
            double a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
                       Math.Cos(startLat.ToRad()) * Math.Cos(destLat.ToRad()) *
                       Math.Sin(dLon / 2) * Math.Sin(dLon / 2);
            double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
            double d = R * c;
            return d;
        }
    }
}
