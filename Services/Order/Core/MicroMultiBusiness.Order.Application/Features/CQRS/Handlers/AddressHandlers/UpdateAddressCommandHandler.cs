using MicroMultiBusiness.Order.Application.Features.CQRS.Commands.AddressCommands;
using MicroMultiBusiness.Order.Application.Interfaces;
using MicroMultiBusiness.Order.Domain.Entites;

namespace MicroMultiBusiness.Order.Application.Features.CQRS.Handlers.AddressHandlers
{
    public class UpdateAddressCommandHandler
    {
        private readonly IRepository<Address> _repository;

        public UpdateAddressCommandHandler(IRepository<Address> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateAddressCommand command)
        {
            var address = await _repository.GetByIdAsync(command.AddressId);
            address.Detail1 = command.Detail1;
            address.Detail2 = command.Detail2;
            address.Description = command.Description;
            address.Email = command.Email;
            address.FirstName = command.FirstName;
            address.LastName = command.LastName;
            address.Phone = command.Phone;
            address.ZipCode = command.ZipCode;
            address.Country = command.Country;
            address.City = command.City;
            address.UserId = command.UserId;
            address.District = command.District;
            await _repository.UpdateAsync(address);
        }
    }
}
