using MicroMultiBusiness.Order.Domain.Entites;
using Microsoft.EntityFrameworkCore;

namespace MicroMultiBusiness.Order.Persistance.Context
{
    public class OrderContext : DbContext
    {
        override protected void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer("Server=CAN-TOKHAY-MASA\\CANTOKHAY ;initial Catalog=MicroMultiBusinessOrderDb; User Id=sa;Password=230491Can.; integrated Security=true;");
        }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Ordering> Orderings { get; set; }
    }
}
