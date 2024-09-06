using MicroMultiBusiness.DTOLayer.BasketDTOs;

namespace MicroMultiBusiness.WebUI.Services.BasketServices
{
    public interface IBasketService
    {
        Task AddBasketItem(BasketItemDTO basketItemDTO);
        Task DeleteBasket(string userId);
        Task<BasketTotalDTO> GetBasket();
        Task<bool> RemoveBasketItem(string productId);
        Task SaveBasket(BasketTotalDTO basketTotalDTO);
    }
}
