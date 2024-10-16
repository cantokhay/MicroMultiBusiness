namespace MicroMultiBusiness.WebUI.Services.StatisticServices.MessageStatistics
{
    public interface IMessageStatisticService
    {
        Task<int> GetTotalMessageCount();
    }
}
