using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Weather.Infrastructure.Services.Weather;
using Weather.Model.Domain;

namespace Weather.Application.Weather
{
    public static class WeatherApp
    {

        public static string GetSunriseTime(double latitude, double longitude, string date)
        {
            // Get sunrise time from service as XML
            string sunriseTime = WeatherService.GetWeatherSystem().Sunrise(latitude, longitude, date);

            return sunriseTime;
        }

        public static Forecast GetWeather(Place place)
        { 
            // hent varsel URL fra database
            // LocationService.GetVarselUrl(placeId) trenger ikke å gjøre dette
            // Få Forecast data fra WeatherService, bruk place.ForecastUrl
            // Forecast forecast =  WeatherService.GetForcastData(place)
            // 

            




            return null;
        
        }

        public static Forecast GetWeatherForecast(Place place)
        {
            Forecast forecast = WeatherService.GetWeatherSystem().GetUpcommingForecast(place);

            return forecast;
        }

        public static IList<Forecast> GetWeatherForecastLongTerm(Place place)
        {
            IList<Forecast> forecasts = WeatherService.GetWeatherSystem().GetForecasts(place);

            return forecasts;
        }
    }
}
