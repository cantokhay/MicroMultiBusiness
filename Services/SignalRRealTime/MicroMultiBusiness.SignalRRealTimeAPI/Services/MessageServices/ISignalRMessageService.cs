namespace MicroMultiBusiness.SignalRRealTimeAPI.Services.MessageServices
{
    public interface ISignalRMessageService
    {
        Task<int> GetTotalMessageCountByReceiverId(string id);
    }
}
