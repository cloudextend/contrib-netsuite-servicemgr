using Microsoft.Extensions.Configuration;
using Celigo.ServiceManager.NetSuite.TSA;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddThreeStepAuthorizationSupport(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddOptions()
                .Configure<TokenServiceOptions>(configuration.GetSection("Celigo:NetSuite:TBA"))

                .AddHttpClient()                

                .AddSingleton<ITokenService, DefaultTokenService>();

            services.AddHttpClient<IAccessTokenService, AccessTokenService>();
            services.AddHttpClient<IRequestTokenService, RequestTokenService>();
            services.AddHttpClient<IRevokeTokenService, RevokeTokenService>();

            return services;
        }
    }
}
