using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Weather.Model.Common;
using Weather.Model.Domain;
using Weather.Infrastructure.Services.Weather.Entities;

namespace Weather.Application.Common
{
    /// <summary>
    /// These are application extension methods.
    /// Working on apllication, infrastructure, and model objects.
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

        public static IList<Forecast> SetImageUrl(this IList<Forecast> arg, bool sizeBig)
        {
            foreach (Forecast forecast in arg)
                forecast.ImageUrl = Helpers.WeatherImageUrl(forecast.SymbolVar, sizeBig);

            return arg;
        }
    }
}
