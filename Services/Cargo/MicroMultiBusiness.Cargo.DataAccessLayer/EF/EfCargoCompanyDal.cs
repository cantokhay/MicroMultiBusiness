using MicroMultiBusiness.Cargo.DataAccessLayer.Abstract;
using MicroMultiBusiness.Cargo.DataAccessLayer.Concrete;
using MicroMultiBusiness.Cargo.DataAccessLayer.Repositories;
using MicroMultiBusiness.Cargo.EntityLayer.Concrete;

namespace MicroMultiBusiness.Cargo.DataAccessLayer.EF
{
    public class EfCargoCompanyDal : GenericRepository<CargoCompany>, ICargoCompanyDal
    {
        public EfCargoCompanyDal(CargoContext context) : base(context) { }
    }
}
