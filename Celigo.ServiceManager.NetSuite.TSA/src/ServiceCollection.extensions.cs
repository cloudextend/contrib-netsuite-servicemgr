using Microsoft.Extensions.Configuration;
using Celigo.ServiceManager.NetSuite.TSA;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddThreeStepAuthorizationSupport(this IServiceCollection services, IConfiguration configuration)
        {
            return services
                .AddOptions()
                .Configure<TokenServiceOptions>(configuration.GetSection("Celigo:NetSuite:TBA"))
                .AddSingleton<TokenService, DefaultTokenService>();
        }
    }
}
