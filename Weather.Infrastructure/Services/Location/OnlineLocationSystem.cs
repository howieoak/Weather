using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Weather.Model.Domain;
using Weather.Infrastructure.Dao;
using Weather.Infrastructure.Spring;
using Weather.Infrastructure.Dao.Entities;
using Spring.Caching;

namespace Weather.Infrastructure.Services.Location
{
    public class OnlineLocationSystem : ILocationSystem
    {
        /// <summary>
        /// Gets all places from database. The result is cached for 10 Hours
        /// </summary>
        /// <returns></returns>
        [CacheResult(CacheName = "ExpiringCache", Key = "'AllPlaces'", TimeToLive = "10:0:0")]
        public IList<Place> GetAllPlaces(string countryCode)
        {
            IList<Place> myPlaces = new List<Place>();
            
            IPlacesNorwayDao dao = SpringObjectLocator.GetObject("PlacesNorwayDao") as PlacesNorwayDao;
            IList<PlaceNorway> places = dao.QueryAllPlaces();

            foreach (PlaceNorway place in places)
            {
                Place myPlace = new Place 
                {
                    PlaceId = place.PlaceId,
                    PlaceName = place.Stadnamn,
                    PlaceType = place.StadtypeBokmål,
                    County = place.Kommune,
                    State = place.Fylke,
                    Latitude = place.Lat,
                    Longitude = place.Lon,
                    CountryCode = "NO",
                    ForecastUri = place.Bokmål
                };

                myPlaces.Add(myPlace);
            }

            return myPlaces;
        }

        /// <summary>
        /// Gets all churches from database. The result is cached for 10 Hours
        /// </summary>
        /// <returns></returns>
        [CacheResult(CacheName = "ExpiringCache", Key = "'AllChurches'", TimeToLive = "10:0:0")]
        public IList<Place> GetAllChurches(string countryCode)
        {

            IList<Place> myChurches = new List<Place>();

            IPlacesNorwayDao dao = SpringObjectLocator.GetObject("PlacesNorwayDao") as PlacesNorwayDao;
            IList<PlaceNorway> churches = dao.QueryAllChurches();

            foreach (PlaceNorway place in churches)
            {
                Place myChurch = new Place
                {
                    PlaceId = place.PlaceId,
                    PlaceName = place.Stadnamn,
                    PlaceType = place.StadtypeBokmål,
                    County = place.Kommune,
                    State = place.Fylke,
                    Latitude = place.Lat,
                    Longitude = place.Lon,
                    CountryCode = "NO",
                    ForecastUri = place.Bokmål
                };

                myChurches.Add(myChurch);
            }

            return myChurches;
        }
    }
}
