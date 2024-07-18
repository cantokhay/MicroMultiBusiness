using MicroMultiBusiness.Order.Application.Features.CQRS.Queries.OrderDetailQueries;
using MicroMultiBusiness.Order.Application.Features.CQRS.Results.AddressResults;
using MicroMultiBusiness.Order.Application.Features.CQRS.Results.OrderDetailResults;
using MicroMultiBusiness.Order.Application.Interfaces;
using MicroMultiBusiness.Order.Domain.Entites;

namespace MicroMultiBusiness.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers
{
    public class GetOrderDetailByIdQueryHandler
    {
        private readonly IRepository<OrderDetail> _repository;

        public GetOrderDetailByIdQueryHandler(IRepository<OrderDetail> repository)
        {
            _repository = repository;
        }

        public async Task<GetOrderDetailByIdQueryResult> Handle(GetOrderDetailByIdQuery query)
        {
            var orderDetail = await _repository.GetByIdAsync(query.Id);
            return new GetOrderDetailByIdQueryResult
            {
                OrderDetailId = orderDetail.OrderDetailId,
                ProductAmount = orderDetail.ProductAmount,
                ProductId = orderDetail.ProductId,
                ProductName = orderDetail.ProductName,
                OrderingId = orderDetail.OrderingId,
                ProductPrice = orderDetail.ProductPrice,
                ProductTotalPrice = orderDetail.ProductTotalPrice
            };
        }
    }
}
