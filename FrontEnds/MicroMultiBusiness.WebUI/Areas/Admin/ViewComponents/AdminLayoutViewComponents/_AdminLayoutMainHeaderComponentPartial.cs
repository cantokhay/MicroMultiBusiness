using MicroMultiBusiness.WebUI.Services.Abstract;
using MicroMultiBusiness.WebUI.Services.MessageServices;
using MicroMultiBusiness.WebUI.Services.StatisticServices.CommentStatistics;
using Microsoft.AspNetCore.Mvc;

namespace MicroMultiBusiness.WebUI.Areas.Admin.ViewComponents.AdminLayoutViewComponents
{
    public class _AdminLayoutMainHeaderComponentPartial : ViewComponent
    {
        private readonly IMessageService _messageService;
        private readonly IUserService _userService;
        private readonly ICommentStatisticService _commentStatisticService;

        public _AdminLayoutMainHeaderComponentPartial(IMessageService messageService, IUserService userService, ICommentStatisticService commentStatisticService)
        {
            _messageService = messageService;
            _userService = userService;
            _commentStatisticService = commentStatisticService;
        }

        public async Task<IViewComponentResult>InvokeAsync()
        {
            var user = await _userService.GetUserInfo(); 
            int messageCount = await _messageService.GetTotalMessageCountByReceiverId(user.Id);
            int commentCount = await _commentStatisticService.GetTotalCommentsCountAsync();
            ViewBag.CommentCount = commentCount;
            ViewBag.MessageCount = messageCount;
            return View();
        }
    }
}