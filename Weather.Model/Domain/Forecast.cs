using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Weather.Model.Domain
{
    public class Forecast
    {
        public Place Location { get; set; }
        public string LocationName { get; set; }
        public int TimePeriod { get; set; }
        public DateTime TimeFrom { get; set; }
        public DateTime TimeTo { get; set; }
        public string SymbolName { get; set; }
        public string SymbolNumber { get; set; }
        public string SymbolVar { get; set; }
        public string ImageUrl { get; set; }
        public double Presipitation { get; set; }
        public double PresipitationMin { get; set; }
        public double PresipitationMax { get; set; }
        public int Temperature { get; set; }
    }
}
