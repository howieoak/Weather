using System.Collections.Generic;
using Weather.Infrastructure.Dao.Entities;

namespace Weather.Infrastructure.Dao
{
    public interface IPlacesNorwayDao
    {
        PlaceNorway GetPlace(int id);
        IList<PlaceNorway> QueryAllPlaces();
        IList<PlaceNorway> QueryAllChurches();
    }
}
