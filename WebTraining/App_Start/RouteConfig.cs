using System.Web.Mvc;
using System.Web.Routing;

namespace WebTraining
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute("dummy", "abcd/junk",
                   new { controller = "Home", action = "index"}
                   );
            routes.MapRoute("Default", "{controller}/{action}/{id}",
                new {controller = "Album", action = "index", id = UrlParameter.Optional}
                );
            routes.MapRoute(
               "Product",
               "xyz/{albumId}",
               new { controller = "Album", action = "detail" },
               new { albumId = @"\d+" }
               );
        }
    }
}