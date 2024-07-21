using MicroMultiBusiness.Cargo.DataAccessLayer.Abstract;
using MicroMultiBusiness.Cargo.DataAccessLayer.Concrete;
using MicroMultiBusiness.Cargo.DataAccessLayer.Repositories;
using MicroMultiBusiness.Cargo.EntityLayer.Concrete;

namespace MicroMultiBusiness.Cargo.DataAccessLayer.EF
{
    public class EfCargoCustomerDal : GenericRepository<CargoCustomer>, ICargoCustomerDal
    {
        public EfCargoCustomerDal(CargoContext context) : base(context) { }
    }
}
