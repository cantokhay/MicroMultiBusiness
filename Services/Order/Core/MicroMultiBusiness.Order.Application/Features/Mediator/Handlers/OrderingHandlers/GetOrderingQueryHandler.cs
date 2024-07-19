using MediatR;
using MicroMultiBusiness.Order.Application.Features.Mediator.Queries.OrderingQueries;
using MicroMultiBusiness.Order.Application.Features.Mediator.Results.OrderingResults;
using MicroMultiBusiness.Order.Application.Interfaces;
using MicroMultiBusiness.Order.Domain.Entites;

namespace MicroMultiBusiness.Order.Application.Features.Mediator.Handlers.OrderingHandlers
{
    public class GetOrderingQueryHandler : IRequestHandler<GetOrderingQuery, List<GetOrderingQueryResult>>
    {
        private readonly IRepository<Ordering> _repository;

        public GetOrderingQueryHandler(IRepository<Ordering> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetOrderingQueryResult>> Handle(GetOrderingQuery request, CancellationToken cancellationToken)
        {
            var orderingList = await _repository.GetAllAsync();
            return orderingList.Select(x => new GetOrderingQueryResult
            {
                OrderingId = x.OrderingId,
                OrderDate = x.OrderDate,
                TotalPrice = x.TotalPrice,
                UserId = x.UserId
            }).ToList();
        }
    }
}
