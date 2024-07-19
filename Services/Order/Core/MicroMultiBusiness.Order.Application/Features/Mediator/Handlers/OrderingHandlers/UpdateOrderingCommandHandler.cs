using MediatR;
using MicroMultiBusiness.Order.Application.Features.Mediator.Commands.OrderingCommands;
using MicroMultiBusiness.Order.Application.Interfaces;
using MicroMultiBusiness.Order.Domain.Entites;

namespace MicroMultiBusiness.Order.Application.Features.Mediator.Handlers.OrderingHandlers
{
    public class UpdateOrderingCommandHandler : IRequestHandler<UpdateOrderingCommand>
    {
        private readonly IRepository<Ordering> _repository;

        public UpdateOrderingCommandHandler(IRepository<Ordering> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateOrderingCommand request, CancellationToken cancellationToken)
        {
            var ordering = await _repository.GetByIdAsync(request.OrderingId);
            ordering.OrderDate = request.OrderDate;
            ordering.TotalPrice = request.TotalPrice;
            ordering.UserId = request.UserId;
            await _repository.UpdateAsync(ordering);

        }
    }
}
