﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;
using Weather.Model.Domain;
using Weather.Model.Common;
using Weather.Infrastructure.Services.Location;
using System.Collections;


namespace Weather.RestService
{
    // Start the service and browse to http://<machine_name>:<port>/Service1/help to view the service's generated help page
    // NOTE: By default, a new instance of the service is created for each call; change the InstanceContextMode to Single if you want
    // a single instance of the service to process all calls.	
    [ServiceContract]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    // NOTE: If the service is renamed, remember to update the global.asax.cs file
    public class LocationRestService
    {
        // TODO: Implement the collection resource that will contain the SampleItem instances

        //[WebGet(UriTemplate = "")]
        //public List<SampleItem> GetCollection()
        //{
        //    // TODO: Replace the current implementation to return a collection of SampleItem instances
        //    return new List<SampleItem>() { new SampleItem() { Id = 1, StringValue = "Hello" } };
        //}

        //[WebInvoke(UriTemplate = "", Method = "POST")]
        //public SampleItem Create(SampleItem instance)
        //{
        //    // TODO: Add the new instance of SampleItem to the collection
        //    throw new NotImplementedException();
        //}

        //[WebGet(UriTemplate = "{id}")]
        //public SampleItem Get(string id)
        //{
        //    // TODO: Return the instance of SampleItem with the given id
        //    throw new NotImplementedException();
        //}

        //[WebInvoke(UriTemplate = "{id}", Method = "PUT")]
        //public SampleItem Update(string id, SampleItem instance)
        //{
        //    // TODO: Update the given instance of SampleItem in the collection
        //    throw new NotImplementedException();
        //}

        //[WebInvoke(UriTemplate = "{id}", Method = "DELETE")]
        //public void Delete(string id)
        //{
        //    // TODO: Remove the instance of SampleItem with the given id from the collection
        //    throw new NotImplementedException();
        //}

        [WebGet(ResponseFormat=WebMessageFormat.Json)]
        public IList<Place> GetChurchesTop()
        {
            IList<Place> allChurches = LocationService.GetLocationSystem().GetAllChurches("NO");
            return allChurches.Take(10).ToList();
        }

        [WebGet(ResponseFormat = WebMessageFormat.Json)]
        public Place GetClosestPlace(string countryCode, double latitude, double longitude)
        {
            Dictionary<Place, double> allDistances = new Dictionary<Place, double>();

            IList<Place> allPlaces = LocationService.GetLocationSystem().GetAllPlaces(countryCode);

            foreach (Place place in allPlaces)
            {
                double distance = Helpers.CalculateDistance(place.Latitude, place.Longitude, latitude, longitude);
                allDistances.Add(place, distance);
            }

            return allDistances.OrderBy(x => x.Value).ToDictionary(x => x.Key, x => x.Value).Keys.First();
        }

        [WebGet(ResponseFormat = WebMessageFormat.Json)]
        public Place GetPlace()
        {
            double longitude = 10.7460923576733;
            double latitude = 59.912726542422;
            
            Dictionary<Place, double> allDistances = new Dictionary<Place, double>();

            IList<Place> allPlaces = LocationService.GetLocationSystem().GetAllPlaces("NO");

            foreach (Place place in allPlaces)
            {
                double distance = Helpers.CalculateDistance(place.Latitude, place.Longitude, latitude, longitude);
                allDistances.Add(place, distance);
            }

            var plass = allDistances.OrderBy(x => x.Value).ToDictionary(x => x.Key, x => x.Value).Keys.First();
            
            return plass;

        }

    }
}
