using MicroMultiBusiness.Order.Application.Features.CQRS.Queries.AddressQueries;
using MicroMultiBusiness.Order.Application.Features.CQRS.Results.AddressResults;
using MicroMultiBusiness.Order.Application.Interfaces;
using MicroMultiBusiness.Order.Domain.Entites;

namespace MicroMultiBusiness.Order.Application.Features.CQRS.Handlers.AddressHandlers
{
    public class GetAddressByIdQueryHandler
    {
        private readonly IRepository<Address> _repository;

        public GetAddressByIdQueryHandler(IRepository<Address> repository)
        {
            _repository = repository;
        }

        public async Task<GetAddressByIdQueryResult> Handle(GetAddressByIdQuery query)
        {
            var address = await _repository.GetByIdAsync(query.Id);
            return new GetAddressByIdQueryResult
            {
                AddressId = address.AddressId,
                City = address.City,
                Detail = address.Detail,
                District = address.District,
                UserId = address.UserId
            };
        }
    }
}
