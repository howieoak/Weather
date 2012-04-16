using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Weather.Model.Domain;

namespace Weather.Infrastructure.Services.Weather.Entities
{
    public class ForecastDto
    {
        public string LocationName { get; set; }
        public string TimePeriod { get; set; }
        public string TimeFrom { get; set; }
        public string TimeTo { get; set; }
        public string SymbolName { get; set; }
        public string SymbolNumber { get; set; }
        public string SymbolVar { get; set; }
        public string Presipitation { get; set; }
        public string PresipitationMin { get; set; }
        public string PresipitationMax { get; set; }
        public string Temperature { get; set; }

        public Forecast ToForecast(Place place)
        {
            Forecast forecast = new Forecast
            {
                Location = place,
                LocationName = this.LocationName,
                TimePeriod = Int32.Parse(this.TimePeriod),
                TimeFrom = DateTime.Parse(this.TimeFrom),
                TimeTo = DateTime.Parse(this.TimeTo),
                SymbolName = this.SymbolName,
                SymbolNumber = this.SymbolNumber,
                SymbolVar = this.SymbolVar,
                Presipitation = Double.Parse(this.Presipitation),
                PresipitationMin = Double.Parse(this.PresipitationMin),
                PresipitationMax = Double.Parse(this.PresipitationMax),
                Temperature = Int32.Parse(this.Temperature)
            };

            return forecast;
        }
    }
}
