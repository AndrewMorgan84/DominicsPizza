using DominicsPizza.Entities;
using DominicsPizza.Repositories;
using DominicsPizza.Repositories.Implementation;
using DominicsPizza.Repositories.Interfaces;
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

            services.AddTransient<ICartRepository, CartRepository>();
            services.AddTransient<IRepository<Item>, Repository<Item>>();
            services.AddTransient<IRepository<Category>, Repository<Category>>();
            services.AddTransient<IRepository<ItemType>, Repository<ItemType>>();
            services.AddTransient<IRepository<CartItem>, Repository<CartItem>>();
        }
    }
}
