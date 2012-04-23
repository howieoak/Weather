using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Http;
using Weather.Model.Common;
using Weather.Infrastructure.Common;
using Weather.Infrastructure.Xml;
using Weather.Model.Domain;
using Weather.Infrastructure.Services.Weather.Entities;

namespace Weather.Infrastructure.Services.Weather
{
    public class OnlineWeatherSystem : IWeatherSystem
    {
        string baseAddress = "http://api.yr.no/weatherapi/";
        HttpClient client; // = new HttpClient();

        public OnlineWeatherSystem()
        {
            client = new HttpClient() { BaseAddress = new Uri(baseAddress) };
        }

        /// <summary>
        /// Henter Sunrise informasjon fra Yr.
        /// Eksempel uri: http://api.yr.no/weatherapi/sunrise/1.0/?lat=59.912726542422;lon=10.7460923576733;date=2012-03-30
        /// </summary>
        /// <param name="latitude">Breddegrad for lokasjon</param>
        /// <param name="longitude">Lengdegrad for lokasjon</param>
        /// <param name="date">Dato i fromat YYYY-MM-DD (år, måned, dag</param>
        /// <returns>The sunrise time as String.</returns>
        public string Sunrise(double latitude, double longitude, string date)
        { 
            string uri = string.Format("sunrise/1.0/?lat={0};lon={1};date={2}", latitude.ToStringPeriod(), longitude.ToStringPeriod(), date);
            string xml = client.GetStringAsync(uri).Result;
            string sunriseTime = YrXmlParser.GetSunriseTime(xml);

            return sunriseTime;
        }

        /// <summary>
        /// Gets a nine day forcast information og the location
        /// Eksempel URI: http://api.yr.no/weatherapi/locationforecast/1.8/?lat=60.10;lon=9.58 
        /// </summary>
        /// <param name="latitude"></param>
        /// <param name="longitude"></param>
        /// <returns></returns>
        public string LocationForecast(double latitude, double longitude)
        {
            string uri = string.Format("locationforecast/1.8/?lat={0};lon={1}", latitude.ToStringPeriod(), longitude.ToStringPeriod());
            string result = client.GetStringAsync(uri).Result;
            //Parse xml and return an object graph,


            return result;
        }

        /// <summary>
        /// Eksempel URL: http://www.yr.no/sted/Norge/Hedmark/Kongsvinger/Gjermshus/varsel.xml
        /// </summary>
        /// <param name="place"></param>
        /// <returns></returns>
        public Forecast GetUpcommingForecast(Place place)
        {
            ForecastDto forecastDto = YrXmlParser.GetUpcommingForecast(place);

            return forecastDto.ToForecast(place);    
        }

        public IList<Forecast> GetForecasts(Place place)
        {
            IList<ForecastDto> forecastList = YrXmlParser.GetForecasts(place);

            return forecastList.ToForecastList(place);
        }



        //public void Countries()
        //{
        //    string uri = "http://api.worldbank.org/countries";

        //    string countries = client.GetStringAsync(uri).Result;
        //}
    }
}
