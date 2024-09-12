using MicroMultiBusiness.DTOLayer.OrderDTOs.OrderingDTOs;

namespace MicroMultiBusiness.WebUI.Services.OrderServices.OrderingServices
{
    public class OrderingService : IOrderingService
    {
        private readonly HttpClient _httpClient;

        public OrderingService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<ResultOrderingByUserIdDTO>> GetOrderingsByUserIdAsync(string userId)
        {
            var response = await _httpClient.GetAsync("orderings/GetOrderingListByUserId?id=" + userId);
            var valueList = await response.Content.ReadFromJsonAsync<List<ResultOrderingByUserIdDTO>>();
            return valueList;
        }
    }
}
