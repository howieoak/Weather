using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Weather.Model.Domain;
using Weather.Infrastructure.Services.Weather.Entities;

namespace Weather.Infrastructure.Xml
{
    /// <summary>
    /// Takes weather data from Yr in an xml format and converts to a more readable string format. 
    /// </summary>
    public static class YrXmlParser
    {
        /// <summary>
        /// Converts the xml string to sunrise time
        /// </summary>
        /// <param name="xmlFromService">the xml string from service</param>
        /// <returns>sunrise time as string</returns>
        public static string GetSunriseTime(string xmlFromService)
        {
            //<astrodata xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xsi:noNamespaceSchemaLocation="http://api.yr.no/weatherapi/sunrise/1.0/schema">
            //  <meta licenseurl="http://api.yr.no/license.html" />
            //  <time date="2012-03-30">
            //    <location latitude="59.912726542422" longitude="10.7460923576733">
            //      <sun rise="2012-03-30T04:47:34Z" set="2012-03-30T17:56:39Z">
            //        <noon altitude="34.1329790832943" />
            //      </sun>
            //      <moon phase="First quarter" rise="2012-03-30T08:09:00Z" set="2012-03-31T02:21:44Z" />
            //    </location>
            //  </time>
            //</astrodata>

            XElement astrodata = XElement.Parse(xmlFromService);
            
            //XElement sun = (from s in astrodata.Elements("time").Elements("location").Elements("sun")
            //                select s).FirstOrDefault();
            XElement sun = astrodata.Elements("time")
                                    .Elements("location")
                                    .Elements("sun")
                                    .FirstOrDefault();


            return (sun.Attribute("rise") != null) ? sun.Attribute("rise").Value : "";
        }

        public static string GetLocationForcast(string xmlFromService)
        {
            return null;
        }

        public static ForecastDto GetForecastData(Place place)
        {
            XElement weatherdata = XElement.Load(place.ForecastUri);

            XElement time = weatherdata.Elements("forecast")
                                       .Elements("tabular")
                                       .Elements("time")
                                       //.Where (p => p.Attribute("period").Value == "1")
                                       .FirstOrDefault();

            XElement symbol = time.Elements("symbol")
                                  .FirstOrDefault();

            XElement precipitation = time.Elements("precipitation")
                                         .FirstOrDefault();

            XElement temperature = time.Elements("temperature")
                                       .FirstOrDefault();

            
            ForecastDto forecastDto = new ForecastDto
            {
                LocationName = place.PlaceName,
                TimePeriod = time.Attribute("period").Value,
                TimeFrom = time.Attribute("from").Value,
                TimeTo = time.Attribute("to").Value,
                SymbolName = symbol.Attribute("name").Value,
                SymbolNumber = symbol.Attribute("number").Value,
                SymbolVar = symbol.Attribute("var").Value,
                Presipitation = precipitation.Attribute("value").Value,
                PresipitationMin = (precipitation.Attribute("value").Value != "0") ? precipitation.Attribute("minvalue").Value : "0",
                PresipitationMax = (precipitation.Attribute("value").Value != "0") ? precipitation.Attribute("maxvalue").Value : "0",
                Temperature = temperature.Attribute("value").Value
            };

            return forecastDto;
        }
    }
}
