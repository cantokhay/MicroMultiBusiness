namespace MicroMultiBusiness.SignalRRealTimeAPI.Services.CommentServices
{
    public interface ISignalRCommentService
    {
        Task<int> GetTotalCommentsCountAsync();
    }
}
