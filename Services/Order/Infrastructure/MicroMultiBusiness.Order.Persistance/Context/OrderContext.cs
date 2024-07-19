using MicroMultiBusiness.Order.Domain.Entites;
using Microsoft.EntityFrameworkCore;

namespace MicroMultiBusiness.Order.Persistance.Context
{
    public class OrderContext : DbContext
    {
        override protected void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer("Server=localhost,1440;initial Catalog=MicroMultiBusinessOrderDb;User=sa;Password=230491Can.");
        }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Ordering> Orderings { get; set; }
    }
}
