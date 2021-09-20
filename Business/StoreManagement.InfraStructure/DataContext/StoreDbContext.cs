using Microsoft.EntityFrameworkCore;
using StoreManagement.Domain.Model;

namespace StoreManagement.Infrastructure.DataContext
{
    public class StoreDbContext : DbContext
    {
        public StoreDbContext(DbContextOptions<StoreDbContext> options) : base(options)
        {

        }

        public DbSet<Product> Product { get; set; }
        public DbSet<Basqet> Basqet { get; set; }
        public DbSet<Customer> Customer { get; set; }
    }
}
