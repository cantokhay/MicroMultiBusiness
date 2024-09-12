using MicroMultiBusiness.Order.Domain.Entites;

namespace MicroMultiBusiness.Order.Application.Interfaces
{
    public interface IOrderingRepository
    {
        List<Ordering> GetAllOrderingsByUserId(string id);
    }
}
