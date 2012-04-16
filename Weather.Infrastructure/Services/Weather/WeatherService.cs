using Weather.Infrastructure.Spring;

namespace Weather.Infrastructure.Services.Weather
{
    public static class WeatherService
    {
        public static IWeatherSystem GetWeatherSystem()
        {
            WeatherSystem ws = SpringObjectLocator.GetObject("WeatherSystemObject") as WeatherSystem;

            return ws.CurrentWeatherSystem;
        }
    }
}
