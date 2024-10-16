
namespace MicroMultiBusiness.WebUI.Services.StatisticServices.CatalogStatistics
{
    public class CatalogStatisticServices : ICatalogStatisticServices
    {
        private readonly HttpClient _httpClient;

        public CatalogStatisticServices(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<decimal> GetAvgProductPrice()
        {
            var response = await _httpClient.GetAsync("Statistics/GetAvgProductPrice");
            var value = await response.Content.ReadFromJsonAsync<decimal>();
            return value;
        }

        public async Task<long> GetBrandCount()
        {
            var response = await _httpClient.GetAsync("Statistics/GetBrandCount");
            var value = await response.Content.ReadFromJsonAsync<long>();
            return value;
        }

        public async Task<long> GetCategoryCount()
        {
            var response = await _httpClient.GetAsync("Statistics/GetCategoryCount");
            var value = await response.Content.ReadFromJsonAsync<long>();
            return value;
        }

        public async Task<string> GetMaxPriceProductName()
        {
            var response = await _httpClient.GetAsync("Statistics/GetMaxPriceProductName");
            var value = await response.Content.ReadAsStringAsync();
            return value;
        }

        public async Task<string> GetMinPriceProductName()
        {
            var response = await _httpClient.GetAsync("Statistics/GetMinPriceProductName");
            string value = await response.Content.ReadAsStringAsync();
            return value;
        }

        public async Task<long> GetProductCount()
        {
            var response = await _httpClient.GetAsync("Statistics/GetProductCount");
            var value = await response.Content.ReadFromJsonAsync<long>();
            return value;
        }
    }
}
