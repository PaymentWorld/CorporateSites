using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Codebase.Website.Pw
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //routes.MapRoute(
            //    "default", // Route name
            //    "{controller}/{action}/{type}", // URL with parameters
            //    new { controller = "home", action = "Index", type = UrlParameter.Optional },
            //    new []{ "NmcCorp.Areas.merchant.Controllers" }// Parameter defaults
            //);

            routes.Add(
                "route_type",
                new Route("{controller}/{action}/{type}", new RouteValueDictionary(new { controller = "home", action = "index", type = UrlParameter.Optional }), new HyphenatedRouteHandler())
            );

            routes.Add(
                "route_default",
                new Route("{controller}/{action}/{id}", new RouteValueDictionary(new { controller = "home", action = "index", id = UrlParameter.Optional }), new HyphenatedRouteHandler())
            );
        }

        protected void Application_Start()
        {
            //Uri website = this.Context.Request.Url;

            //AreaRegistration.RegisterAllAreas(website);

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);
        }
    }

    public class HyphenatedRouteHandler : MvcRouteHandler
    {
        protected override IHttpHandler GetHttpHandler(RequestContext requestContext)
        {
            requestContext.RouteData.Values["controller"] = requestContext.RouteData.Values["controller"].ToString().Replace("-", "_");
            requestContext.RouteData.Values["action"] = requestContext.RouteData.Values["action"].ToString().Replace("-", "_");

            return base.GetHttpHandler(requestContext);
        }
    }
}