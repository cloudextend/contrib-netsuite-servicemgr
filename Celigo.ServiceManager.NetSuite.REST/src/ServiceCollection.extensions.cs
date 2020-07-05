using System;
using System.Net.Http;
using System.Xml.Schema;
using Celigo.ServiceManager.NetSuite.REST;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddNetSuiteRestClientSupport(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddOptions()
                .Configure<RestClientOptions>(configuration.GetSection(RestClientOptions.ConfigurationSectionName))
                .AddHttpClient()
                ;

            return services;
        }

        public static IServiceCollection AddRestletClient(this IServiceCollection services,
                                                            IConfiguration configuration, 
                                                            params RestletConfig[] restlets)
        {
            services.AddNetSuiteRestClientSupport(configuration);

            Array.ForEach(restlets, r => {
                _ = r.RestletName ?? throw new ArgumentNullException($"{nameof(RestletConfig)}.{nameof(RestletConfig.RestletName)}");
                services.AddSingleton(r);
            });

            services.AddSingleton<IRestletClientFactory, RestletClientFactory>();


            return services;
        }
    }
}