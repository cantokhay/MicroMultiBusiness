using MicroMultiBusiness.Discount.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace MicroMultiBusiness.Discount.Context
{
    public class DapperContext : DbContext
    {
        //dapper configuration

        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public DapperContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("DefaultConnection");
        }
        override protected void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            //optionsBuilder.UseSqlServer("Server=CAN-TOKHAY-MASA\\CANTOKHAY ;initial Catalog=MicroMultiBusinessDiscountDb; User Id=sa;Password=230491Can.; integrated Security=true;");
            optionsBuilder.UseSqlServer("Server=DESKTOP-OHO9G30\\SQLEXPRESS ;initial Catalog=MicroMultiBusinessDiscountDb; integrated Security=true;");
        }
        public DbSet<Coupon> Coupons { get; set; }
        public IDbConnection CreateConnection() => new SqlConnection(_connectionString);
    }
}
