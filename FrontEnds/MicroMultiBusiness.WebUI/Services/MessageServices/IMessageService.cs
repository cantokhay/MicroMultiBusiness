using MicroMultiBusiness.DTOLayer.MessageDTOs;

namespace MicroMultiBusiness.WebUI.Services.MessageServices
{
    public interface IMessageService
    {
        Task<List<ResultInboxMessageDTO>> GetAllInboxMessagesAsync(string id);
        Task<List<ResultSendboxMessageDTO>> GetAllSendboxMessagesAsync(string id);
        Task<int> GetTotalMessageCountByReceiverId(string id);

        //Task<List<ResultMessageDTO>> GetAllMessagesAsync();
        //Task CreateMessageAsync(CreateMessageDTO createMessageDTO);
        //Task<GetByIdMessageDTO> GetByIdMessageAsync(int id);
        //Task UpdateMessageAsync(UpdateMessageDTO updateMessageDTO);
        //Task DeleteMessageAsync(int id);
    }
}
