using MicroMultiBusiness.Order.Application.Features.CQRS.Commands.OrderDetailCommands;
using MicroMultiBusiness.Order.Application.Interfaces;
using MicroMultiBusiness.Order.Domain.Entites;

namespace MicroMultiBusiness.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers
{
    public class CreateOrderDetailCommandHandler
    {
        private readonly IRepository<OrderDetail> _repository;

        public CreateOrderDetailCommandHandler(IRepository<OrderDetail> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateOrderDetailCommand command)
        {
           await _repository.CreateAsync(new OrderDetail
           {
               ProductAmount = command.ProductAmount,
               ProductId = command.ProductId,
               OrderingId = command.OrderingId,
               ProductPrice = command.ProductPrice,
               ProductName = command.ProductName,
               ProductTotalPrice = command.ProductTotalPrice
           });
        }
    }
}
