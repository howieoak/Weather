using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using Weather.Model.Domain;
using Weather.Infrastructure.Services.Weather;


namespace Weather.RestService
{
    // Start the service and browse to http://<machine_name>:<port>/Service1/help to view the service's generated help page
    // NOTE: By default, a new instance of the service is created for each call; change the InstanceContextMode to Single if you want
    // a single instance of the service to process all calls.	
    [ServiceContract]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    // NOTE: If the service is renamed, remember to update the global.asax.cs file
    public class WeatherRestService
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

        [WebGet(ResponseFormat = WebMessageFormat.Json)]
        public string GetWeatherForecast()
        {
            //double longitude = 10.7460923576733;
            //double latitude = 59.912726542422;

            ////return WeatherService.GetWeatherSystem().LocationForecast(latitude, longitude);
            //Place place = new Place() { CountryCode = "NO", Latitude = latitude, Longitude = longitude };


            //Forecast forecast = WeatherService.GetWeatherSystem().GetUpcommingForecast(place);

            //return forecast.ToString();

            //string forecastUri = "http://www.yr.no/sted/Norge/Oslo/Oslo/Vesletjern/varsel.xml";

            //OnlineWeatherSystem target = new OnlineWeatherSystem();
            //Forecast result = target.GetUpcommingForecast(new Place { ForecastUri = forecastUri });

            return "";
        }



    }
}