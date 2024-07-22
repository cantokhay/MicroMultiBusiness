using MicroMultiBusiness.Basket.DTOs;

namespace MicroMultiBusiness.Basket.Services
{
    public interface IBasketService
    {
        Task<BasketTotalDTO> GetBasket(string userId);
        Task SaveBasket(BasketTotalDTO basketTotalDTO);
        Task DeleteBasket(string userId);
    }
}
