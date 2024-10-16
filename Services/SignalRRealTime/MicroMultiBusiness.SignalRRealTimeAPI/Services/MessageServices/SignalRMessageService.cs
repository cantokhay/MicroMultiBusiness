namespace MicroMultiBusiness.SignalRRealTimeAPI.Services.MessageServices
{
    public class SignalRMessageService : ISignalRMessageService
    {
        private readonly HttpClient _httpClient;

        public SignalRMessageService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<int> GetTotalMessageCountByReceiverId(string id)
        {
            var response = await _httpClient.GetAsync("UserMessages/GetTotalMessageCountByReceiverId?id=" + id);
            var value = await response.Content.ReadFromJsonAsync<int>();
            return value;
        }
    }
}
