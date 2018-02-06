using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using System.Web.Http;
using Autofac;
using System.Reflection;
using Autofac.Integration.WebApi;
using WebApiWithOWIN.Services;
using NLog.Owin.Logging;
using WebApiWithOWIN.LoggerService;
using Microsoft.Owin.Logging;
using WebApiWithOWIN.LoggerAbstract;
using System.IO;

[assembly: OwinStartup(typeof(WebApiWithOWIN.Startup))]

namespace WebApiWithOWIN
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var config = new HttpConfiguration();
            var builder = new ContainerBuilder();

            builder.RegisterModule(new NLogOwinModule());
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterType<Test>().As<ITest>().SingleInstance();

            //builder.RegisterType<Logger.LoggerService>().AsImplementedInterfaces().InstancePerDependency();
            //builder.RegisterType<Logger.ConsoleLogger>().AsImplementedInterfaces().InstancePerDependency();
            //builder.RegisterType<Logger.ApiLogger>().AsImplementedInterfaces().InstancePerDependency();
            //builder.RegisterType<Logger.FileLogger>().AsImplementedInterfaces().InstancePerDependency();

            //builder.RegisterType<LoggerAbstract.LoggerService>().As<LoggerAbstract.ILoggerService>().InstancePerDependency();
            //builder.RegisterType<LoggerAbstract.ConsoleLogger>().AsImplementedInterfaces().InstancePerDependency();
            //builder.RegisterType<LoggerAbstract.ApiLogger>().AsImplementedInterfaces().InstancePerDependency();
            //builder.RegisterType<LoggerAbstract.FileLogger>().AsImplementedInterfaces().InstancePerDependency();

            builder.RegisterType<LoggerEvent.LoggerService>().AsImplementedInterfaces().InstancePerDependency();
            builder.RegisterType<LoggerEvent.ConsoleLogger>().AsImplementedInterfaces().InstancePerDependency();
            builder.RegisterType<LoggerEvent.ApiLogger>().AsImplementedInterfaces().InstancePerDependency();
            builder.RegisterType<LoggerEvent.FileLogger>().AsImplementedInterfaces().InstancePerDependency();

            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);

            app.UseWebApi(config);
            app.UseNLog();

            RegisterRoutes(config);
        }

        public void RegisterRoutes(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
