using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Celigo.ServiceManager.NetSuite.TSA
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
