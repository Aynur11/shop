using Domain;
using Microsoft.EntityFrameworkCore;
using System;

namespace Persistence
{
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
}