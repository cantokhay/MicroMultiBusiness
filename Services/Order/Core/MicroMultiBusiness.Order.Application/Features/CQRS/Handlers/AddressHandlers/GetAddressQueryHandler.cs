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
                Detail1 = address.Detail1,
                Detail2 = address.Detail2,
                Description = address.Description,
                District = address.District,
                Email = address.Email,
                FirstName = address.FirstName,
                LastName = address.LastName,
                Phone = address.Phone,
                ZipCode = address.ZipCode,
                Country = address.Country,
                UserId = address.UserId
            }).ToList();
        }
    }
}
