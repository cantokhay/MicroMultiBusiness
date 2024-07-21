using MicroMultiBusiness.Cargo.EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;

namespace MicroMultiBusiness.Cargo.DataAccessLayer.Concrete
{
    public class CargoContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost,1441;initial Catalog=MicroMultiBusinessCargoDb;User=sa;Password=230491Can.");
        }

        public DbSet<CargoCustomer> CargoCustomers { get; set; }
        public DbSet<CargoCompany> CargoCompanies { get; set; }
        public DbSet<CargoOperation> CargoOperations { get; set; }
        public DbSet<CargoDetail> CargoDetails { get; set; }
    }
}
