using AutoMapper;
using MicroMultiBusiness.Message.DAL.Context;
using MicroMultiBusiness.Message.DAL.Entities;
using MicroMultiBusiness.Message.DTOs;
using Microsoft.EntityFrameworkCore;

namespace MicroMultiBusiness.Message.Services
{
    public class UserMessageService : IUserMessageService
    {
        private readonly MessageContext _context;
        private readonly IMapper _mapper;

        public UserMessageService(MessageContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task CreateMessageAsync(CreateMessageDTO createMessageDTO)
        {
            var value = _mapper.Map<UserMessage>(createMessageDTO);
            await _context.UserMessages.AddAsync(value);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteMessageAsync(int id)
        {
            var value = await _context.UserMessages.FindAsync(id);
            _context.UserMessages.Remove(value);
            await _context.SaveChangesAsync();
        }

        public async Task<List<ResultInboxMessageDTO>> GetAllInboxMessagesAsync(string id)
        {
            var valueList = await _context.UserMessages.Where(x => x.ReceiverId == id).ToListAsync();
            return _mapper.Map<List<ResultInboxMessageDTO>>(valueList);
        }

        public async Task<List<ResultMessageDTO>> GetAllMessagesAsync()
        {
            var valueList = await _context.UserMessages.ToListAsync();
            return _mapper.Map<List<ResultMessageDTO>>(valueList);
        }

        public async Task<List<ResultSendboxMessageDTO>> GetAllSendboxMessagesAsync(string id)
        {
            var valueList = await _context.UserMessages.Where(x => x.SenderId == id).ToListAsync();
            return _mapper.Map<List<ResultSendboxMessageDTO>>(valueList);
        }

        public async Task<GetByIdMessageDTO> GetByIdMessageAsync(int id)
        {
            var value = await _context.UserMessages.FindAsync(id);
            return _mapper.Map<GetByIdMessageDTO>(value);
        }

        public async Task<int> GetTotalMessageCount()
        {
            int value = await _context.UserMessages.CountAsync();
            return value;
        }

        public async Task<int> GetTotalMessageCountByReceiverId(string id)
        {
            var value = await _context.UserMessages.Where(x => x.ReceiverId == id).CountAsync();
            return value;
        }

        public async Task UpdateMessageAsync(UpdateMessageDTO updateMessageDTO)
        {
            var valueToUpdate = _mapper.Map<UserMessage>(updateMessageDTO);
            _context.UserMessages.Update(valueToUpdate);
            await _context.SaveChangesAsync();
        }
    }
}
