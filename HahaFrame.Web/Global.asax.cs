using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using HahaFrame.Web.App_Start;
using HahaFrame.Web.Infrastructure;
using Autofac.Core;
using Autofac.Integration.Mvc;
using NLog;

namespace HahaFrame.Web
{
    // Note: For instructions on enabling IIS7 classic mode, 
    // visit http://go.microsoft.com/fwlink/?LinkId=301868
    public class MvcApplication : System.Web.HttpApplication
    {
        public static Autofac.IContainer Container;
        private static Logger _loggingService = LogManager.GetCurrentClassLogger();

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AuthConfig.RegisterAuth();

            //System.Web.Optimization.BundleTable.EnableOptimizations = false;

            Container = IoC.Initialize();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(Container));

            //remove all view engines
            ViewEngines.Engines.Clear();
            //except the themeable razor view engine we use
            ViewEngines.Engines.Add(new ThemeableRazorViewEngine());
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            var error = Server.GetLastError();
            _loggingService.FatalException("Uncaught Exception", error);
        }
    }
}
