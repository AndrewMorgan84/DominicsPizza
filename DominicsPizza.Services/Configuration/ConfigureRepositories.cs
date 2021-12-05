using DominicsPizza.Entities;
using DominicsPizza.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DominicsPizza.Services.Configuration
{
    public class ConfigureRepositories
    {
        public static void AddServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>((options) => 
            {
                options.UseSqlServer(configuration.GetConnectionString("DbConnection"));
            });
            services.AddIdentity<User, Role>()
                .AddEntityFrameworkStores<AppDbContext>()
                .AddDefaultTokenProviders();
            services.AddScoped<DbContext, AppDbContext>();
        }
    }
}
