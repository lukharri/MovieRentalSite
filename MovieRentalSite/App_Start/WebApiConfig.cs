using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace MovieRentalSite
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            /*
             * Properties of JSON objects returned from calling API are named with Pascal case
             * Consuming these objects in JavaScript may cause problems
             * Convert to camelCase to prevent any problems 
             */
            var settings = config.Formatters.JsonFormatter.SerializerSettings;
            settings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            settings.Formatting = Formatting.Indented;

            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
