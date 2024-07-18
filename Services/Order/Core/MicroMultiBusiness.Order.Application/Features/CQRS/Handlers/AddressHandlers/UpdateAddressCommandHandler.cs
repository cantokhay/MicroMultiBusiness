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
            address.Detail = command.Detail;
            address.City = command.City;
            address.UserId = command.UserId;
            address.District = command.District;
            await _repository.UpdateAsync(address);
        }
    }
}
