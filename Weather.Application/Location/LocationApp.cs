﻿using System.Collections.Generic;
using System.Linq;
using System.Globalization;
using Weather.Model.Domain;
using Weather.Model.Common;
using Weather.Infrastructure.Services.Location;
using System.Collections;

namespace Weather.Application.Location
{
    public static class LocationApp
    {
        public static IList<Place> GetPlacesTop(string countryCode, int count)
        {
            IList<Place> allPlaces = LocationService.GetLocationSystem().GetAllPlaces(countryCode);
            return allPlaces.Take(count).ToList();
        }
        
        public static IList<Place> GetPlacesThatStartsWith(string countryCode, string query)
        {
            IList<Place> allPlaces = LocationService.GetLocationSystem().GetAllPlaces(countryCode);

            return allPlaces.Where(x => x.PlaceName.StartsWith(query)).ToList();
        }

        public static IList<Place> GetChurchesAll(string countryCode)
        {
            return LocationService.GetLocationSystem().GetAllChurches(countryCode);
        }

        public static IList<Place> GetChurchesTop(string countryCode, int count)
        {
            IList<Place> allChurches = LocationService.GetLocationSystem().GetAllChurches(countryCode);
            return allChurches.Take(count).ToList();
        }

        public static Place GetPlace(string countryCode, int id)
        {
            IList<Place> allPlaces = LocationService.GetLocationSystem().GetAllPlaces(countryCode);

            return allPlaces.SingleOrDefault(x => x.PlaceId == id);
        }

        public static object AutocompleteGetPlacesTopThatContains(string countryCode, int count, string query)
        {
            IList<Place> allPlaces = LocationService.GetLocationSystem().GetAllPlaces(countryCode);
            return allPlaces.Where(x => x.PlaceName.Contains(query)).Take(count).Select(r => new { label = r.PlaceName });
        }

        public static object AutocompleteGetPlacesThatStartsWith(string countryCode, string query)
        {
            IList<Place> allPlaces = LocationService.GetLocationSystem().GetAllPlaces(countryCode);
            var places = allPlaces.Where(x => x.PlaceName.StartsWith(query, true, CultureInfo.InvariantCulture)).Select(r => new { 
                            label = r.PlaceName + ", " + r.PlaceType + ", " + r.County + ", " + r.State,
                            value = r.ToString() });
            //var places = allPlaces.Where(x => x.PlaceName.StartsWith(query)).Select(r => new { label = r.PlaceName });

            return places;
        }

        public static Place GetClosestPlace(string countryCode, double latitude, double longitude)
        {
            Dictionary<Place,double> allDistances = new Dictionary<Place,double>();

            IList<Place> allPlaces = LocationService.GetLocationSystem().GetAllPlaces(countryCode);

            foreach (Place place in allPlaces)
            {
                double distance = Helpers.CalculateDistance(place.Latitude, place.Longitude, latitude, longitude);
                allDistances.Add(place, distance);
            }

            return allDistances.OrderBy(x => x.Value).ToDictionary(x => x.Key, x => x.Value).Keys.First(); 
        }
    }
}
