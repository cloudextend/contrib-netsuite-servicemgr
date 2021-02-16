using System;
using System.Linq;
using System.Net.Http;
using System.Xml.Schema;
using Celigo.ServiceManager.NetSuite.REST;
using Microsoft.Extensions.Configuration;

namespace Microsoft.Extensions.DependencyInjection
{
    using Options = Microsoft.Extensions.Options.Options;
    
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddNetSuiteRestClientSupport(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddOptions()
                .Configure<RestClientOptions>(configuration.GetSection(RestClientOptions.ConfigurationSectionName))
                .AddHttpClient()
                .AddHttpClient<IRestClient, RestClient>();

            return services;
        }

        public static IServiceCollection AddRestletClient(this IServiceCollection services,
                                                            IConfiguration configuration, 
                                                            params RestletConfig[] restlets)
        {
            services
                .AddNetSuiteRestClientSupport(configuration)
                .Configure<RestletConfig>(configuration.GetSection(RestletConfig.ConfigurationSectionName))
                .Configure<RestletConfigOptions>(configuration.GetSection(RestletConfig.ConfigurationSectionName));

            if (restlets.Length > 0)
            {
                var restletConfigOptions = new RestletConfigOptions { Restlets = restlets };
                if (restlets.Any(r => string.IsNullOrEmpty(r.RestletName)))
                {
                    throw new ArgumentNullException($"{nameof(RestletConfig)}.{nameof(RestletConfig.RestletName)}");
                }
                services.AddSingleton(Options.Create(restletConfigOptions));
            }

            services.AddHttpClient<IRestletClient, RestletClient>();
            
            services.AddSingleton<IRestletClientFactory, RestletClientFactory>();

            return services;
        }
    }
}