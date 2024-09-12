using MicroMultiBusiness.DTOLayer.OrderDTOs.OrderingDTOs;

namespace MicroMultiBusiness.WebUI.Services.OrderServices.OrderingServices
{
    public interface IOrderingService
    {
        Task<List<ResultOrderingByUserIdDTO>> GetOrderingsByUserIdAsync(string userId);
    }
}
