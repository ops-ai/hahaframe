using System;
using System.Collections.Generic;
using System.Reflection;
using System.Web;
using HahaFrame.Data;
using HahaFrame.Data.Caching;
using HahaFrame.Data.Repository;
using HahaFrame.Services.Articles;
using HahaFrame.Services.Cache;
using HahaFrame.Services.ContactUs;
using HahaFrame.Services.Emails;
using HahaFrame.Services.Frame;
using HahaFrame.Services.Globals;
using HahaFrame.Services.KnowledgeBases;
using HahaFrame.Services.StaticPages;
using HahaFrame.Web.Controllers;
using AuthorizeNet;
using Autofac;
using Autofac.Builder;
using Autofac.Core;
using Autofac.Integration.Mvc;
using System.Configuration;

namespace HahaFrame.Web.Infrastructure
{
    public static class IoC
    {
        public static IContainer Initialize()
        {
            var builder = new ContainerBuilder();
            //HTTP context and other related stuff

            builder.RegisterControllers(Assembly.GetExecutingAssembly());

            builder.Register(c => new HttpContextWrapper(HttpContext.Current) as HttpContextBase)
                .As<HttpContextBase>()
                .InstancePerHttpRequest();
            builder.Register(c => c.Resolve<HttpContextBase>().Request)
                .As<HttpRequestBase>()
                .InstancePerHttpRequest();
            builder.Register(c => c.Resolve<HttpContextBase>().Response)
                .As<HttpResponseBase>()
                .InstancePerHttpRequest();
            builder.Register(c => c.Resolve<HttpContextBase>().Server)
                .As<HttpServerUtilityBase>()
                .InstancePerHttpRequest();
            builder.Register(c => c.Resolve<HttpContextBase>().Session)
                .As<HttpSessionStateBase>()
                .InstancePerHttpRequest();

            //data layer
            var dataSettingsManager = new DataSettingsManager();
            var dataProviderSettings = dataSettingsManager.LoadSettings();
            builder.Register(c => dataSettingsManager.LoadSettings()).As<DataSettings>();
            builder.Register(x => new EfDataProviderManager(x.Resolve<DataSettings>())).As<BaseDataProviderManager>().InstancePerDependency();


            builder.Register(x => (IEfDataProvider)x.Resolve<BaseDataProviderManager>().LoadDataProvider()).As<IDataProvider>().InstancePerDependency();
            builder.Register(x => (IEfDataProvider)x.Resolve<BaseDataProviderManager>().LoadDataProvider()).As<IEfDataProvider>().InstancePerDependency();

            if (dataProviderSettings != null && dataProviderSettings.IsValid())
            {
                var efDataProviderManager = new EfDataProviderManager(dataSettingsManager.LoadSettings());
                var dataProvider = (IEfDataProvider)efDataProviderManager.LoadDataProvider();
                dataProvider.InitConnectionFactory();

                builder.Register<IDbContext>(c => new NopObjectContext(dataProviderSettings.DataConnectionString)).InstancePerHttpRequest();
            }
            else
            {
                builder.Register<IDbContext>(c => new NopObjectContext(dataSettingsManager.LoadSettings().DataConnectionString)).InstancePerHttpRequest();
            }


            builder.RegisterGeneric(typeof(EfRepository<>)).As(typeof(IRepository<>)).InstancePerHttpRequest();

            //cache manager
            builder.RegisterType<MemoryCacheManager>().As<ICacheManager>().Named<ICacheManager>("nop_cache_static").SingleInstance();
            builder.RegisterType<PerRequestCacheManager>().As<ICacheManager>().Named<ICacheManager>("nop_cache_per_request").InstancePerHttpRequest();

            builder.RegisterType<EmailNotificationController>().As<IEmailNotificationService>().InstancePerHttpRequest();

            //services
            builder.RegisterType<GlobalService>().As<IGlobalService>().InstancePerHttpRequest();
            builder.RegisterType<StaticPageService>().As<IStaticPageService>().InstancePerHttpRequest();
            builder.RegisterType<KnowledgeBaseService>().As<IKnowledgeBaseService>().InstancePerHttpRequest();
            builder.RegisterType<ArticleService>().As<IArticleService>().InstancePerHttpRequest();
            builder.RegisterType<ContactUsService>().As<IContactUsService>().InstancePerHttpRequest();
            builder.RegisterType<FrameService>().As<IFrameService>().InstancePerHttpRequest();

            builder.Register<IGateway>(c => new Gateway(ConfigurationManager.AppSettings["ApiLogin"], ConfigurationManager.AppSettings["TransactionKey"], ConfigurationManager.AppSettings["AuthorizeNetTestMode"] == "true")).InstancePerHttpRequest();

            builder.RegisterSource(new SettingsSource());

            return builder.Build();
        }
    }

    public class SettingsSource : IRegistrationSource
    {
        static readonly MethodInfo BuildMethod = typeof(SettingsSource).GetMethod(
            "BuildRegistration",
            BindingFlags.Static | BindingFlags.NonPublic);

        public IEnumerable<IComponentRegistration> RegistrationsFor(Service service, Func<Service, IEnumerable<IComponentRegistration>> registrations)
        {
            var ts = service as TypedService;
            if (ts != null && typeof(ISettings).IsAssignableFrom(ts.ServiceType))
            {
                var buildMethod = BuildMethod.MakeGenericMethod(ts.ServiceType);
                yield return (IComponentRegistration)buildMethod.Invoke(null, null);
            }
        }

        static IComponentRegistration BuildRegistration<TSettings>() where TSettings : ISettings, new()
        {
            return RegistrationBuilder.ForDelegate((c, p) =>
                {
                    return c.Resolve<ISettingService>().LoadSetting<TSettings>();
                })
                .InstancePerHttpRequest()
                .CreateRegistration();
        }

        public bool IsAdapterForIndividualComponents { get { return false; } }
    }
}