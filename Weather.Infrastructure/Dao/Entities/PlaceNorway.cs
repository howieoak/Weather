namespace Weather.Infrastructure.Dao.Entities
{
    public class PlaceNorway
    {
        public int PlaceId { get; set; }
        public int Kommunenummer { get; set; }
        public string Stadnamn { get; set; }
        public int Prioritet { get; set; }
        public string StadtypeNynorsk { get; set; }
        public string StadtypeBokmål { get; set; }
        public string StadtypeEngelsk { get; set; }
        public string Kommune { get; set; }
        public string Fylke { get; set; }
        public double Lat { get; set; }
        public double Lon { get; set; }
        public int Høgd { get; set; }
        public string Nynorsk { get; set; }
        public string Bokmål { get; set; }
        public string Engelsk { get; set; }
    }
}
