using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Weather.Model.Domain;

namespace Weather.Infrastructure.Services.Location
{
    public interface ILocationSystem
    {
        IList<Place> GetAllPlaces(string countryCode);
        IList<Place> GetAllChurches(string countryCode);
    }
}
