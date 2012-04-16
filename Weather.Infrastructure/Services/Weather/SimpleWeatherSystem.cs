using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Weather.Infrastructure.Services.Weather
{
    public class SimpleWeatherSystem : IWeatherSystem
    {
        public string Sunrise(double latitude, double longitude, string date)
        {
            string xml = @"<astrodata xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance' xsi:noNamespaceSchemaLocation='http://api.yr.no/weatherapi/sunrise/1.0/schema'>
              <meta licenseurl='http://api.yr.no/license.html' />
              <time date='2012-03-30'>
                <location latitude='59.912726542422' longitude='10.7460923576733'>
                  <sun rise='2012-03-30T04:47:34ZThis is from Simple' set='2012-03-30T17:56:39Z'>
                    <noon altitude='34.1329790832943' />
                  </sun>
                  <moon phase='First quarter' rise='2012-03-30T08:09:00Z' set='2012-03-31T02:21:44Z' />
                </location>
              </time>
            </astrodata>";

            return xml;
        }

        public string LocationForecast(double latitude, double longitude)
        {
            throw new NotImplementedException();
        }


        public Model.Domain.Forecast ForcastData(Model.Domain.Place place)
        {
            throw new NotImplementedException();
        }

    }
}
