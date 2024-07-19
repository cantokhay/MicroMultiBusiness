using MicroMultiBusiness.Order.Application.Features.CQRS.Results.AddressResults;
using MicroMultiBusiness.Order.Application.Interfaces;
using MicroMultiBusiness.Order.Domain.Entites;

namespace MicroMultiBusiness.Order.Application.Features.CQRS.Handlers.AddressHandlers
{
    public class GetAddressQueryHandler
    {
        private readonly IRepository<Address> _repository;

        public GetAddressQueryHandler(IRepository<Address> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetAddressQueryResult>> Handle()
        {
            var addressList = await _repository.GetAllAsync();
            return addressList.Select(address => new GetAddressQueryResult
            {
                AddressId = address.AddressId,
                City = address.City,
                Detail = address.Detail,
                District = address.District,
                UserId = address.UserId
            }).ToList();
        }
    }
}
