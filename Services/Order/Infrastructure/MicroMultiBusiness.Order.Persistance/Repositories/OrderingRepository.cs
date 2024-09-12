using MicroMultiBusiness.Order.Application.Interfaces;
using MicroMultiBusiness.Order.Domain.Entites;
using MicroMultiBusiness.Order.Persistance.Context;

namespace MicroMultiBusiness.Order.Persistance.Repositories
{
    public class OrderingRepository : IOrderingRepository
    {
        private readonly OrderContext _context;

        public OrderingRepository(OrderContext context)
        {
            _context = context;
        }

        public List<Ordering> GetAllOrderingsByUserId(string id)
        {
            var valueList = _context.Orderings.Where(x => x.UserId == id).ToList();
            return valueList;
        }
    }
}
