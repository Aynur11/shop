using Application.Interfaces;
using Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class DataContext : IdentityDbContext<ApplicationUser>, IDataContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<FirstLevelIconSection> FirstLevelIconSections { get; set; }
        public DbSet<FirstLevelImageSection> FirstLevelImageSections { get; set; }
        public DbSet<SecondLevelSection> SecondLevelSections { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .Entity<Product>(e =>
                {
                    e.Property(p => p.QuantityInStock)
                    .HasConversion(p => p.Value, p => ProductQuantity.Create(p).Value);
                })
                .Entity<OrderItem>(e =>
                {
                    e.Property(p => p.Quantity)
                    .HasConversion(p => p.Value, p => ProductQuantity.Create(p).Value);
                });
            base.OnModelCreating(builder);
        }
    }
}