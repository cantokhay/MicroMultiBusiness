using MediatR;
using MicroMultiBusiness.Order.Application.Features.Mediator.Results.OrderingResults;

namespace MicroMultiBusiness.Order.Application.Features.Mediator.Queries.OrderingQueries
{
    public class GetOrderingByUserIdQuery : IRequest<List<GetOrderingByUserIdQueryResult>>
    {
        public string Id { get; set; }

        public GetOrderingByUserIdQuery(string id)
        {
            Id = id;
        }
    }
}
