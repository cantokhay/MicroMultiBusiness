using MediatR;
using MicroMultiBusiness.Order.Application.Features.Mediator.Queries.OrderingQueries;
using MicroMultiBusiness.Order.Application.Features.Mediator.Results.OrderingResults;
using MicroMultiBusiness.Order.Application.Interfaces;
using MicroMultiBusiness.Order.Domain.Entites;

namespace MicroMultiBusiness.Order.Application.Features.Mediator.Handlers.OrderingHandlers
{
    public class GetOrderingByIdQueryHandler : IRequestHandler<GetOrderingByIdQuery, GetOrderingByIdQueryResult>
    {
        private readonly IRepository<Ordering> _repository;

        public GetOrderingByIdQueryHandler(IRepository<Ordering> repository)
        {
            _repository = repository;
        }

        public async Task<GetOrderingByIdQueryResult> Handle(GetOrderingByIdQuery request, CancellationToken cancellationToken)
        {
            var ordering = await _repository.GetByIdAsync(request.Id);
            return new GetOrderingByIdQueryResult
            {
                OrderingId = ordering.OrderingId,
                OrderDate = ordering.OrderDate,
                TotalPrice = ordering.TotalPrice,
                UserId = ordering.UserId
            };
        }
    }
}
