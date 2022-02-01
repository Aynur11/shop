using Application.Interfaces;
using Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class DataContext : IdentityDbContext<ApplicationUser>, IDataContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            // Использовать для пересоздания БД.
            //Database.EnsureDeleted();
            //Database.EnsureCreated();
        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
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

            builder.Entity<FirstLevelImageSection>()
                .HasOne(f => f.FirstLevelIconSection)
                .WithMany(f => f.FirstLevelImageSections)
                .HasForeignKey(f => f.FirstLevelIconSectionId);

            builder.Entity<SecondLevelSection>()
                .HasOne(f => f.FirstLevelImageSection)
                .WithOne(f => f.SecondLevelSection)
                .HasForeignKey<FirstLevelImageSection>(f => f.Id);
            
            base.OnModelCreating(builder);
        }
    }
}