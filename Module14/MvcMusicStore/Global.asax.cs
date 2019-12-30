using Autofac;
using Autofac.Integration.Mvc;
using MvcMusicStore.Controllers;
using MvcMusicStore.Infrastructure;
using NLog;
using PerformanceCounterHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace MvcMusicStore
{
    public class MvcApplication : System.Web.HttpApplication
    {
        private readonly ILogger logger;
        public MvcApplication()
        {
            logger = LogManager.GetCurrentClassLogger();
        }
        protected void Application_Start()
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(typeof(HomeController).Assembly);
            builder.Register(f => LogManager.GetLogger("ForControllers")).
                As<ILogger>();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(builder.Build()));

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            logger.Info("Application Started");

            using (var counterHelper = PerformanceHelper.CreateCounterHelper<Counters>("Enter Home counter instance"))
            {
                counterHelper.RawValue(Counters.GoToHome, 0);
            }
            using (var counterHelper = PerformanceHelper.CreateCounterHelper<Counters>("Successful Log in counter instance"))
            {
                counterHelper.RawValue(Counters.SuccessLogIn, 0); 
            }
            using (var counterHelper = PerformanceHelper.CreateCounterHelper<Counters>("Successful Log off counter instance"))
            {
                counterHelper.RawValue(Counters.successLogOff, 0);
            }

        }

        protected void Application_Error()
        {
            var ex = Server.GetLastError();

            logger.Error(ex.ToString());
        }
    }
}
