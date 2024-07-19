using MediatR;
using MicroMultiBusiness.Order.Application.Features.Mediator.Results.OrderingResults;

namespace MicroMultiBusiness.Order.Application.Features.Mediator.Queries.OrderingQueries
{
    public class GetOrderingQuery : IRequest<List<GetOrderingQueryResult>>
    {

    }
}
