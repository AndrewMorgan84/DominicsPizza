using DominicsPizza.Services.Implementations;
using DominicsPizza.Services.Interfaces;
using DominicsPizza.WebUI.Helpers;
using DominicsPizza.WebUI.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace DominicsPizza.WebUI.Configuration
{
    public class ConfigureDependencies
    {
        public static void AddServices(IServiceCollection services)
        {
            services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddTransient<IUserAccessor, UserAccessor>();
            services.AddTransient<IPaymentService, PaymentService>();
            services.AddTransient<ICatalogService, CatalogService>();
            services.AddTransient<ICartService, CartService>();
            services.AddTransient<IFileHelper, FileHelper>();
        }
    }
}
