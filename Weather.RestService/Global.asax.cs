using System;
using System.ServiceModel.Activation;
using System.Web;
using System.Web.Routing;

namespace Weather.RestService
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            RegisterRoutes();
        }

        private void RegisterRoutes()
        {
            // Edit the base address of Service1 by replacing the "Service1" string below
            RouteTable.Routes.Add(new ServiceRoute("LocationService", new WebServiceHostFactory(), typeof(LocationRestService)));
            RouteTable.Routes.Add(new ServiceRoute("WeatherService", new WebServiceHostFactory(), typeof(WeatherRestService)));
        }
    }
}
