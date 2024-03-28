using System.Web.Mvc;
using System.Web.Routing;


namespace _3.BonusChallenge
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}"
            );

            routes.MapRoute("SimpleList", "Home/SimpleList", new { controller = "Home", action = "SimpleList" }
            );

            routes.MapRoute("HarderList", "Home/HarderList", new { controller = "Home", action = "HarderList" }
            );

            routes.MapRoute("Default", "{controller}/{action}/{id}", new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
