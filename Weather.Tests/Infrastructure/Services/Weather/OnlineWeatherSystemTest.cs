using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Weather.Infrastructure.Services.Weather;
using Weather.Model.Domain;

namespace Weather.Tests.Infrastructure.Services.Weather
{
    [TestClass]
    public class OnlineWeatherSystemTest
    {
        [TestMethod]
        public void SunriseTest()
        {
            // Stedsinformasjon for Oslo
            // http://api.yr.no/weatherapi/sunrise/1.0/?lat=59.912726542422;lon=10.7460923576733;date=2012-03-30
            //
            double longitude = 10.7460923576733;
            double latitude = 59.912726542422;
            string date = "2012-03-30";

            OnlineWeatherSystem target = new OnlineWeatherSystem();
            string result = target.Sunrise(longitude, latitude, date);
            
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void LocationForecastTest()
        {
            // Stedsinformasjon for Oslo
            // http://api.yr.no/weatherapi/locationforecast/1.8/?lat=60.10;lon=9.58
            //
            double longitude = 10.7460923576733;
            double latitude = 59.912726542422;
            
            OnlineWeatherSystem target = new OnlineWeatherSystem();
            string result = target.LocationForecast(longitude, latitude);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void ForecastDataTest()
        {
            string forecastUri = "http://www.yr.no/sted/Norge/Oslo/Oslo/Vesletjern/varsel.xml";
            
            OnlineWeatherSystem target = new OnlineWeatherSystem();
            Forecast result = target.ForcastData(new Place { ForecastUri = forecastUri });

            Assert.IsNotNull(result);
        }
        
    }
}


