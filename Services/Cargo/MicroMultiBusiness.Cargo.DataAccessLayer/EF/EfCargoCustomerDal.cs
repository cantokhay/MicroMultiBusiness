using MicroMultiBusiness.Cargo.DataAccessLayer.Abstract;
using MicroMultiBusiness.Cargo.DataAccessLayer.Concrete;
using MicroMultiBusiness.Cargo.DataAccessLayer.Repositories;
using MicroMultiBusiness.Cargo.EntityLayer.Concrete;

namespace MicroMultiBusiness.Cargo.DataAccessLayer.EF
{
    public class EfCargoCustomerDal : GenericRepository<CargoCustomer>, ICargoCustomerDal
    {
        private readonly CargoContext _cargoContext;

        public EfCargoCustomerDal(CargoContext context, CargoContext cargoContext) : base(context)
        {
            _cargoContext = cargoContext;
        }

        public CargoCustomer GetCustomerByUserId(string id)
        {
            var value = _cargoContext.CargoCustomers.Where(x => x.UserId == id).FirstOrDefault();
            return value;
        }
    }
}
