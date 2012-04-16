using Weather.Infrastructure.Spring;

namespace Weather.Infrastructure.Services.Location
{
    public static class LocationService
    {
        public static ILocationSystem GetLocationSystem()
        {
            LocationSystem ls = SpringObjectLocator.GetObject("LocationSystemObject") as LocationSystem;
            return ls.CurrentLocationSystem;
        }
    }
}
