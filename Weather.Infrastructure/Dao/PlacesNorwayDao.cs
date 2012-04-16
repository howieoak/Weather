using System;
using System.Collections.Generic;
using System.Data;
using Spring.Data.Generic;
using Spring.Data.Common;
using Weather.Infrastructure.Dao.Entities;

namespace Weather.Infrastructure.Dao
{
    public class PlacesNorwayDao : AdoDaoSupport, IPlacesNorwayDao
    {
        #region IPlacesDao Members

        public PlaceNorway GetPlace(int id)
        {
            IDbParametersBuilder builder = CreateDbParametersBuilder();
            builder.Create().Name("Id").Type(DbType.Int32).Value(id);
            IDbParameters parameters = builder.GetParameters();

            string cmdTxt = "select PlaceId,Kommunenummer,Stadnamn,Prioritet,StadtypeNynorsk,StadtypeBokmål,StadtypeEngelsk,Kommune,Fylke,Lat,Lon,Høgd,Nynorsk,Bokmål,Engelsk from places_norway where PlaceId = @Id";

            return AdoTemplate.QueryForObject<PlaceNorway>(CommandType.Text, cmdTxt, new PlacesRowMapper<PlaceNorway>(), parameters);
        }

        public IList<PlaceNorway> QueryAllPlaces()
        {
           
            //string cmdTxt = "select PlaceId,Kommunenummer,Stadnamn,Prioritet,StadtypeNynorsk,StadtypeBokmål,StadtypeEngelsk,Kommune,Fylke,Lat,Lon,Høgd,Nynorsk,Bokmål,Engelsk from places_norway where Stadnamn Like '%@PlaceName'";
            //string cmdTxt = "select PlaceId,Kommunenummer,Stadnamn,Prioritet,StadtypeNynorsk,StadtypeBokmål,StadtypeEngelsk,Kommune,Fylke,Lat,Lon,Høgd,Nynorsk,Bokmål,Engelsk from places_norway where Stadnamn Like '%Os'";
            string cmdTxt = "select PlaceId,Kommunenummer,Stadnamn,Prioritet,StadtypeNynorsk,StadtypeBokmål,StadtypeEngelsk,Kommune,Fylke,Lat,Lon,Høgd,Nynorsk,Bokmål,Engelsk from places_norway";

            return AdoTemplate.QueryWithRowMapper<PlaceNorway>(CommandType.Text, cmdTxt, new PlacesRowMapper<PlaceNorway>());
        }

       
        public IList<PlaceNorway> QueryAllChurches()
        {
            string cmdTxt = "select PlaceId,Kommunenummer,Stadnamn,Prioritet,StadtypeNynorsk,StadtypeBokmål,StadtypeEngelsk,Kommune,Fylke,Lat,Lon,Høgd,Nynorsk,Bokmål,Engelsk from places_norway where StadtypeBokmål = 'Kirke'";

            return AdoTemplate.QueryWithRowMapper<PlaceNorway>(CommandType.Text, cmdTxt, new PlacesRowMapper<PlaceNorway>());
        }

        #endregion
    }
}
