using Newtonsoft.Json;

namespace MicroMultiBusiness.WebUI.Services.StatisticServices.CommentStatistics
{
    public class CommentStatisticService : ICommentStatisticService
    {
        private readonly HttpClient _httpClient;

        public CommentStatisticService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<int> GetActiveCommentsCountAsync()
        {
            var responseMessage = await _httpClient.GetAsync($"comments/GetActiveCommentsCount");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<int>(jsonData);
            return values;
        }

        public async Task<int> GetPassiveCommentsCountAsync()
        {
            var responseMessage = await _httpClient.GetAsync($"comments/GetPassiveCommentsCount");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<int>(jsonData);
            return values;
        }

        public async Task<int> GetTotalCommentsCountAsync()
        {
            var responseMessage = await _httpClient.GetAsync($"comments/GetTotalCommentsCount");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<int>(jsonData);
            return values;
        }
    }
}
