using System.Web.Mvc;
using System.Web.Routing;

namespace InsuranceApp
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "InsureeAdmin",
                url: "Insuree/Admin",
                defaults: new { controller = "Insuree", action = "Admin" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
