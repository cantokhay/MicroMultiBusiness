using MicroMultiBusiness.DTOLayer.CommentDTOs;

namespace MicroMultiBusiness.WebUI.Services.StatisticServices.CommentStatistics
{
    public interface ICommentStatisticService
    {
        Task<int> GetActiveCommentsCountAsync();
        Task<int> GetPassiveCommentsCountAsync();
        Task<int> GetTotalCommentsCountAsync();
    }
}
