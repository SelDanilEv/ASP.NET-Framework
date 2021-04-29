using System.Web.Mvc;
using System.Web.Mvc.Routing;
using System.Web.Routing;

namespace Lab5b
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapMvcAttributeRoutes();

            routes.MapRoute(
                name: "AResearch",
                url: "{controller}/{action}",
                defaults: new { controller = "AResearch", action = "AA" }
            );

            routes.MapRoute(
                name: "CHResearch",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "CHResearch", action = "AD", id = UrlParameter.Optional }
            );
        }
    }
}