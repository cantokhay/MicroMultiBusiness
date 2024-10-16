
using MicroMultiBusiness.DTOLayer.IdentityDTOs.UserDTOs;
using Newtonsoft.Json;

namespace MicroMultiBusiness.WebUI.Services.StatisticServices.UserStatistics
{
    public class UserStatisticService : IUserStatisticService
    {
        private readonly HttpClient _httpClient;

        public UserStatisticService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<int> GetUserCount()
        {
            var response = await _httpClient.GetAsync("http://localhost:5001/api/Statistics/GetUserCount");
            var jsonData = await response.Content.ReadAsStringAsync();
            var valuesList = JsonConvert.DeserializeObject<int>(jsonData);
            return valuesList;
        }
    }
}
