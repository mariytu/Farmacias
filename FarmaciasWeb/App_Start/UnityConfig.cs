using System;
using System.Configuration;
using System.Net.Http;
using System.Web.Mvc;
using Unity;
using Unity.Injection;
using Unity.Lifetime;
using Unity.Mvc5;
using FarmaciasWeb.Services;
using FarmaciasWeb.Services.API;

namespace FarmaciasWeb
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers
            // e.g. container.RegisterType<ITestService, TestService>();
            //container.RegisterType<>
            //

            //api Client
            var apiURL = ConfigurationManager.AppSettings["FarmaciasApiURI"];
            container.RegisterType<HttpClient>(
                new ContainerControlledLifetimeManager(),
                new InjectionFactory(x => new HttpClient
                {
                    BaseAddress = new Uri(apiURL)
                })
            );
            container.RegisterType<IFarmaciasApiClient, FarmaciasApiClient>(
                new ContainerControlledLifetimeManager()
            );

            //servicios API
            container.RegisterType<IFarmaciasService, FarmaciasService>();
            container.RegisterType<ICommonService, CommonService>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }

        private static HttpClient CreateApiClient(string apiURL)
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri(apiURL)
            };
            return client;
        }
    }
}