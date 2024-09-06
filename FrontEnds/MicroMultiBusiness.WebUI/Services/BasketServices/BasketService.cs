using MicroMultiBusiness.DTOLayer.BasketDTOs;

namespace MicroMultiBusiness.WebUI.Services.BasketServices
{
    public class BasketService : IBasketService
    {
        private readonly HttpClient _httpClient;

        public BasketService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task AddBasketItem(BasketItemDTO basketItemDTO)
        {
            var values = await GetBasket();
            if (values != null)
            {
                if (!values.BasketItems.Any(x => x.ProductId == basketItemDTO.ProductId))
                {
                    values.BasketItems.Add(basketItemDTO);
                }
                else
                {
                    values = new BasketTotalDTO();
                    values.BasketItems.Add(basketItemDTO);
                }
                await SaveBasket(values);
            }
        }

        public Task DeleteBasket(string userId)
        {
            throw new NotImplementedException();
        }

        public async Task<BasketTotalDTO> GetBasket()
        {
            var response = await _httpClient.GetAsync("baskets");
            var values = await response.Content.ReadFromJsonAsync<BasketTotalDTO>();
            return values;
        }

        public async Task<bool> RemoveBasketItem(string productId)
        {
            var values = await GetBasket();
            var deletedItem = values.BasketItems.FirstOrDefault(x => x.ProductId == productId);
            var result = values.BasketItems.Remove(deletedItem);
            await SaveBasket(values);
            return true; //error handling TODO
        }

        public async Task SaveBasket(BasketTotalDTO basketTotalDTO)
        {
            await _httpClient.PostAsJsonAsync<BasketTotalDTO>("baskets", basketTotalDTO);
        }
    }
}
