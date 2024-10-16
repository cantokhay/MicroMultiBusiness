using MicroMultiBusiness.Message.DTOs;

namespace MicroMultiBusiness.Message.Services
{
    public interface IUserMessageService
    {
        Task<List<ResultMessageDTO>> GetAllMessagesAsync();
        Task<List<ResultInboxMessageDTO>> GetAllInboxMessagesAsync(string id);
        Task<List<ResultSendboxMessageDTO>> GetAllSendboxMessagesAsync(string id);
        Task CreateMessageAsync(CreateMessageDTO createMessageDTO);
        Task<GetByIdMessageDTO> GetByIdMessageAsync(int id);
        Task UpdateMessageAsync(UpdateMessageDTO updateMessageDTO);
        Task DeleteMessageAsync(int id);
        Task<int> GetTotalMessageCount();
    }
}
