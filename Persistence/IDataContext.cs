using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public interface IDataContext
    {
        DbSet<Order> Orders { get; set; }
        DbSet<Product> Products { get; set; }
    }
}