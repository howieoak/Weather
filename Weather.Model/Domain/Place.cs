namespace Weather.Model.Domain
{
    public class Place
    {
        public int PlaceId { get; set; }
        public string PlaceName { get; set; }   // By,plass,sted,navn
        public string PlaceType { get; set; }   // Kirke, tettsted osv.
        public string CountryCode { get; set; } // Norge=NO
        public string State { get; set; }       // fylke 
        public string County { get; set; }      // kommune
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string ForecastUri { get; set; }
    }
}
