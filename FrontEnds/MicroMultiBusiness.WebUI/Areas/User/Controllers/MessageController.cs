using MicroMultiBusiness.WebUI.Services.Abstract;
using MicroMultiBusiness.WebUI.Services.MessageServices;
using Microsoft.AspNetCore.Mvc;

namespace MicroMultiBusiness.WebUI.Areas.User.Controllers
{
    [Area("User")]
    public class MessageController : Controller
    {
        private readonly IMessageService _messageService;
        private readonly IUserService _userService;

        public MessageController(IMessageService messageService, IUserService userService)
        {
            _messageService = messageService;
            _userService = userService;
        }

        public async Task<IActionResult> Inbox()
        {
            var user = await _userService.GetUserInfo();
            var valueList = await _messageService.GetAllInboxMessagesAsync( user.Id);
            return View(valueList);
        }

        public async Task<IActionResult> Outbox()
        {
            var user = await _userService.GetUserInfo();
            var valueList = await _messageService.GetAllSendboxMessagesAsync(user.Id);
            return View(valueList);
        }
    }
}
