using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IDataContext
    {
        DbSet<Order> Orders { get; set; }
        DbSet<Product> Products { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
        EntityEntry<TEntity> Update<TEntity>(TEntity entity) where TEntity : class;
    }
}