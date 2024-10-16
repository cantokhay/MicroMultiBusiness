using MicroMultiBusiness.SignalRRealTimeAPI.Services.CommentServices;
using MicroMultiBusiness.SignalRRealTimeAPI.Services.MessageServices;
using Microsoft.AspNetCore.SignalR;

namespace MicroMultiBusiness.SignalRRealTimeAPI.Hubs
{
    public class SignalRHub : Hub
    {
        private readonly ISignalRCommentService _signalRCommentService;

        public SignalRHub(ISignalRCommentService signalRCommentService)
        {
            _signalRCommentService = signalRCommentService;
        }

        public async Task SendStatisticCount()
        {
            var commentCount = await _signalRCommentService.GetTotalCommentsCountAsync();
            await Clients.All.SendAsync("ReceiveCommentCount", commentCount);
        }
    }
}
