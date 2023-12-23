using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace TestWeb
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            SystemWebAdapterConfiguration.AddSystemWebAdapters(this)
              .AddJsonSessionSerializer(options =>
              {
                  // Serialization/deserialization requires each session key to be registered to a type
                  options.RegisterKey<string>("MachineName");
                  options.RegisterKey<string>("PageName");
                  options.RegisterKey<DateTime>("SessionStartTime");
                  //options.RegisterKey<SessionDemoModel>("DemoItem");
              })
              .AddRemoteAppServer(options =>
              {
                  options.ApiKey = ConfigurationManager.AppSettings["RemoteAppApiKey"];
              })
              .AddSessionServer();
        }

        protected void Session_Start(Object sender, EventArgs e)
        {
            HttpContext.Current.Session["MachineName"] = Environment.MachineName;
            HttpContext.Current.Session["PageName"] = "WebApp";
            HttpContext.Current.Session["SessionStartTime"] = DateTime.Now;
        }
    }
}
