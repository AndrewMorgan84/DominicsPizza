using DominicsPizza.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DominicsPizza.Repositories
{
    public class AppDbContext : IdentityDbContext<User, Role, int>
    {
        //Needed for migrations only
        public AppDbContext()
        {

        }

        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {

        }

        public DbSet<Address> Addresses { get; set; }

        public DbSet<Cart> Carts { get; set; }

        public DbSet<CartItem> CartItems { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Item> Items { get; set; }

        public DbSet<ItemType> ItemTypes { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderItem> OrderItems { get; set; }

        public DbSet<Payment> Payments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Needed for migration only
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"data source=DESKTOP-TRA0LPE; initial Catalog=DominicsPizza;integrated security=True;");
            }

            base.OnConfiguring(optionsBuilder);
        }
    }
}
