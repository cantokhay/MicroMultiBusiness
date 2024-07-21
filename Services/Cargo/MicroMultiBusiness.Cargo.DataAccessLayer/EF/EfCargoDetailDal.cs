using MicroMultiBusiness.Cargo.DataAccessLayer.Abstract;
using MicroMultiBusiness.Cargo.DataAccessLayer.Concrete;
using MicroMultiBusiness.Cargo.DataAccessLayer.Repositories;
using MicroMultiBusiness.Cargo.EntityLayer.Concrete;

namespace MicroMultiBusiness.Cargo.DataAccessLayer.EF
{
    public class EfCargoDetailDal : GenericRepository<CargoDetail>, ICargoDetailDal
    {
        public EfCargoDetailDal(CargoContext context) : base(context) { }
    }
}
