using System.Data;
using Spring.Data.Generic;
using Weather.Infrastructure.Dao.Entities;

namespace Weather.Infrastructure.Dao
{
    public class PlacesRowMapper<T> : IRowMapper<T> where T : PlaceNorway, new()
    {
        public T MapRow(IDataReader dataReader, int rowNum)
        {
            T place = new T();
            
            place.PlaceId = dataReader.GetInt32(0);
            place.Kommunenummer = dataReader.GetInt32(1);
            place.Stadnamn = dataReader.GetString(2);
            place.Prioritet = dataReader.GetInt32(3);
            place.StadtypeNynorsk = dataReader.GetString(4);
            place.StadtypeBokmål = dataReader.GetString(5);
            place.StadtypeEngelsk = dataReader.GetString(6);
            place.Kommune = dataReader.GetString(7);
            place.Fylke = dataReader.GetString(8);
            place.Lat = dataReader.GetDouble(9);
            place.Lon = dataReader.GetDouble(10);
            place.Høgd = dataReader.GetInt32(11);
            place.Nynorsk = dataReader.GetString(12);
            place.Bokmål = dataReader.GetString(13);
            place.Engelsk = dataReader.GetString(14);

            return place;
        }

    }
}
