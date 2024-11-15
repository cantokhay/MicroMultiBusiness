﻿using MicroMultiBusiness.Order.Application.Features.CQRS.Commands.AddressCommands;
using MicroMultiBusiness.Order.Application.Interfaces;
using MicroMultiBusiness.Order.Domain.Entites;

namespace MicroMultiBusiness.Order.Application.Features.CQRS.Handlers.AddressHandlers
{
    public class CreateAddressCommandHandler
    {
        private readonly IRepository<Address> _repository;

        public CreateAddressCommandHandler(IRepository<Address> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateAddressCommand createAddressCommand)
        {
            await _repository.CreateAsync(new Address
            {
                City = createAddressCommand.City,
                Detail1 = createAddressCommand.Detail1,
                District = createAddressCommand.District,
                UserId = createAddressCommand.UserId,
                Description = createAddressCommand.Description,
                Email = createAddressCommand.Email,
                FirstName = createAddressCommand.FirstName,
                LastName = createAddressCommand.LastName,
                Phone = createAddressCommand.Phone,
                ZipCode = createAddressCommand.ZipCode,
                Country = createAddressCommand.Country,
                Detail2 = createAddressCommand.Detail2
            });
        }
    }
}
