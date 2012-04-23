using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Weather.Model.Domain;
using Weather.Infrastructure.Services.Weather.Entities;

namespace Weather.Infrastructure.Common
{
    /// <summary>
    /// These are infrastructure extension methods.
    /// Working on infrastructure and model objects.
    /// </summary>
    public static class ExtensionMethods
    {
        ///// <summary>
        /////  Sorts a dictionary by value
        ///// </summary>
        ///// <param name="arg"></param>
        ///// <returns></returns>
        //public static Dictionary<object, object> SortedByValue(this Dictionary<object, object> arg)
        //{
        //    return arg.OrderBy(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
        //}

        public static IList<Forecast> ToForecastList(this IList<ForecastDto> arg, Place place)
        {
            IList<Forecast> list = new List<Forecast>();
            foreach (ForecastDto forecastDto in arg)
                list.Add(forecastDto.ToForecast(place));

            return list;
        }
    }
}
