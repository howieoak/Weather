using Spring.Context;
using Spring.Context.Support;
using Spring.Objects.Factory.Xml;

namespace Weather.Infrastructure.Spring
{
    public static class SpringObjectLocator
    {
        private static IApplicationContext ctx = null;

        private static IApplicationContext GetContainer()
        {
            if (ctx == null)
            {
                ctx = ContextRegistry.GetContext();
            }

            return ctx;
        }

        public static object GetObject(string objectname)
        {
            return GetContainer().GetObject(objectname);
        }
    }
}
