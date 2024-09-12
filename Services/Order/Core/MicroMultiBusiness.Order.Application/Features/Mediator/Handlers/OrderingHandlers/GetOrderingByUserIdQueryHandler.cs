using MediatR;
using MicroMultiBusiness.Order.Application.Features.Mediator.Queries.OrderingQueries;
using MicroMultiBusiness.Order.Application.Features.Mediator.Results.OrderingResults;
using MicroMultiBusiness.Order.Application.Interfaces;

namespace MicroMultiBusiness.Order.Application.Features.Mediator.Handlers.OrderingHandlers
{
    public class GetOrderingByUserIdQueryHandler : IRequestHandler<GetOrderingByUserIdQuery, List<GetOrderingByUserIdQueryResult>>
    {
        private readonly IOrderingRepository _orderingRepository;

        public GetOrderingByUserIdQueryHandler(IOrderingRepository orderingRepository)
        {
            _orderingRepository = orderingRepository;
        }

        public async Task<List<GetOrderingByUserIdQueryResult>> Handle(GetOrderingByUserIdQuery request, CancellationToken cancellationToken)
        {
            var orderingList = _orderingRepository.GetAllOrderingsByUserId(request.Id);
            return orderingList.Select(x => new GetOrderingByUserIdQueryResult
            {
                OrderingId = x.OrderingId,
                OrderDate = x.OrderDate,
                TotalPrice = x.TotalPrice,
                UserId = x.UserId
            }).ToList();
        }
    }
}
