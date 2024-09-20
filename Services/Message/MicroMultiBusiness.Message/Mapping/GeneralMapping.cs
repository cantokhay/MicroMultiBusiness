using AutoMapper;
using MicroMultiBusiness.Message.DAL.Entities;
using MicroMultiBusiness.Message.DTOs;

namespace MicroMultiBusiness.Message.Mapping
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            CreateMap<CreateMessageDTO, UserMessage>().ReverseMap();
            CreateMap<UserMessage, ResultInboxMessageDTO>().ReverseMap();
            CreateMap<UserMessage, ResultMessageDTO>().ReverseMap();
            CreateMap<UserMessage, ResultSendboxMessageDTO>().ReverseMap();
            CreateMap<UserMessage, GetByIdMessageDTO>().ReverseMap();
            CreateMap<UpdateMessageDTO, UserMessage>().ReverseMap();
        }
    }
}
