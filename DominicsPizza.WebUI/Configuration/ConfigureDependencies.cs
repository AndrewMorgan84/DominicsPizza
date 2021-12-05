using DominicsPizza.Services.Implementations;
using DominicsPizza.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace DominicsPizza.WebUI.Configuration
{
    public class ConfigureDependencies
    {
        public static void AddServices(IServiceCollection services)
        {
            services.AddScoped<IAuthenticationService, AuthenticationService>();
        }
    }
}
