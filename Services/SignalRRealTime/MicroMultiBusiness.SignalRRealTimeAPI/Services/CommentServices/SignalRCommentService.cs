using Newtonsoft.Json;
using System.Net.Http;

namespace MicroMultiBusiness.SignalRRealTimeAPI.Services.CommentServices
{
    public class SignalRCommentService : ISignalRCommentService
    {
        private readonly IHttpClientFactory _httpClient;

        public SignalRCommentService(IHttpClientFactory httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<int> GetTotalCommentsCountAsync()
        {
            var client = _httpClient.CreateClient();
            var response = await client.GetAsync("http://localhost:7075/api/CommentStatistics");
            var jsonData = await response.Content.ReadAsStringAsync();
            var commentCount = JsonConvert.DeserializeObject<int>(jsonData);
            return commentCount;
        }

    }
}
