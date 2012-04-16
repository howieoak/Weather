using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Weather.Model.Domain;

namespace Weather.Infrastructure.Services.Weather
{
    public interface IWeatherSystem
    {
        string Sunrise(double latitude, double longitude, string date);
        string LocationForecast(double latitude, double longitude);
        Forecast ForcastData(Place place);
    }
}
