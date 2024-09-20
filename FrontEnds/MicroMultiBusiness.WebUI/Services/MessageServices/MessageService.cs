using MicroMultiBusiness.DTOLayer.MessageDTOs;

namespace MicroMultiBusiness.WebUI.Services.MessageServices
{
    public class MessageService : IMessageService
    {
        private readonly HttpClient _httpClient;

        public MessageService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<ResultInboxMessageDTO>> GetAllInboxMessagesAsync(string id)
        {
            var response = await _httpClient.GetAsync("UserMessages/GetAllInboxMessages?id=" + id);
            var valueList = await response.Content.ReadFromJsonAsync<List<ResultInboxMessageDTO>>();
            return valueList;
        }

        public async Task<List<ResultSendboxMessageDTO>> GetAllSendboxMessagesAsync(string id)
        {
            var response = await _httpClient.GetAsync("UserMessages/GetAllSendboxMessages?id=" + id);
            var valueList = await response.Content.ReadFromJsonAsync<List<ResultSendboxMessageDTO>>();
            return valueList;
        }
    }
}
