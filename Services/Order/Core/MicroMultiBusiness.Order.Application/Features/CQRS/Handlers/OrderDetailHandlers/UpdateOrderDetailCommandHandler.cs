using MicroMultiBusiness.Order.Application.Features.CQRS.Commands.AddressCommands;
using MicroMultiBusiness.Order.Application.Features.CQRS.Commands.OrderDetailCommands;
using MicroMultiBusiness.Order.Application.Interfaces;
using MicroMultiBusiness.Order.Domain.Entites;

namespace MicroMultiBusiness.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers
{
    public class UpdateOrderDetailCommandHandler
    {
        private readonly IRepository<OrderDetail> _repository;

        public UpdateOrderDetailCommandHandler(IRepository<OrderDetail> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateOrderDetailCommand command)
        {
            var orderDetail = await _repository.GetByIdAsync(command.OrderDetailId);
            orderDetail.ProductName = command.ProductName;
            orderDetail.ProductPrice = command.ProductPrice;
            orderDetail.ProductId = command.ProductId;
            orderDetail.ProductAmount = command.ProductAmount;
            orderDetail.ProductTotalPrice = command.ProductTotalPrice;
            orderDetail.OrderingId = command.OrderingId;
            await _repository.UpdateAsync(orderDetail);
        }
    }
}
