using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using WebGrease;

namespace Weather_Forecast
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { area = "HelpPage", controller = "Help", action = "Index", id = UrlParameter.Optional },
                constraints: null,
                namespaces: new[] { "Weather_Forecast.Areas.HelpPage.Controllers" }  
            ).DataTokens.Add("area", "HelpPage"); ;
        }
    }
}
