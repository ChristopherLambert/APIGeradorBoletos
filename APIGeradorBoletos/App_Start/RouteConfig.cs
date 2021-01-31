using System;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

namespace APIGeradorBoletos.App_Start
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                //defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                defaults: new { controller = "", action = "", id = UrlParameter.Optional },
                namespaces: new[] { "APIGeradorBoletos.Controllers" }
            );
        }
    }
}