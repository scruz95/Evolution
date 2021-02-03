using Evolution.Api.App_Start;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Evolution.Api
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Configuración y servicios de API web
            config.EnableCors(new AccessPolicyCors());

            //Solución de inyección de depencias
            UnityConfig container = new UnityConfig();
            config.DependencyResolver = new UnityResolver(container.Register());

            // Rutas de API web
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
