using Microsoft.EntityFrameworkCore;
using Domain;
namespace Persistence;

public class DataContext : DbContext
{
    public DataContext()
    {
    }

    public DataContext(DbContextOptions options) : base(options)
    {

    }

    public DbSet<Order> Orders { get; set; }
}
