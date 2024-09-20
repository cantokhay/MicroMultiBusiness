using MicroMultiBusiness.Message.DTOs;
using MicroMultiBusiness.Message.Services;
using Microsoft.AspNetCore.Mvc;

namespace MicroMultiBusiness.Message.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserMessagesController : ControllerBase
    {
        private readonly IUserMessageService _userMessageService;

        public UserMessagesController(IUserMessageService userMessageService)
        {
            _userMessageService = userMessageService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMessages()
        {
            var valueList = await _userMessageService.GetAllMessagesAsync();
            return Ok(valueList);
        }

        [HttpGet("GetAllSendboxMessages")]
        public async Task<IActionResult> GetAllSendboxMessages(string id)
        {
            var valueList = await _userMessageService.GetAllSendboxMessagesAsync(id);
            return Ok(valueList);
        }

        [HttpGet("GetAllInboxMessages")]
        public async Task<IActionResult> GetAllInboxMessages(string id)
        {
            var valueList = await _userMessageService.GetAllInboxMessagesAsync(id);
            return Ok(valueList);
        }

        [HttpGet("GetByIdMessage")]
        public async Task<IActionResult> GetByIdMessage(int id)
        {
            var value = await _userMessageService.GetByIdMessageAsync(id);
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateMessage(CreateMessageDTO createMessageDTO)
        {
            await _userMessageService.CreateMessageAsync(createMessageDTO);
            return Ok("Created Successfully");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteMessage(int id)
        {
            await _userMessageService.DeleteMessageAsync(id);
            return Ok("Deleted Successfully");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateMessage(UpdateMessageDTO updateMessageDTO)
        {
            await _userMessageService.UpdateMessageAsync(updateMessageDTO);
            return Ok("Updated Successfully");
        }
    }
}
