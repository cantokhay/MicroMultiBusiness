using MicroMultiBusiness.Cargo.BusinessLayer.Abstract;
using MicroMultiBusiness.Cargo.DTOLayer.DTOs.CargoCustomerDTOs;
using MicroMultiBusiness.Cargo.EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MicroMultiBusiness.Cargo.WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoCustomersController : ControllerBase
    {
        private readonly ICargoCustomerService _cargoCustomerService;

        public CargoCustomersController(ICargoCustomerService cargoCustomerService)
        {
            _cargoCustomerService = cargoCustomerService;
        }

        [HttpGet]
        public IActionResult CargoCustomerList()
        {
            var valuesList = _cargoCustomerService.TGetAll();
            return Ok(valuesList);
        }

        [HttpPost]
        public IActionResult CreateCargoCustomer(CreateCargoCustomerDTO createCargoCustomerDTO)
        {
            CargoCustomer createValue = new CargoCustomer()
            {
                Address = createCargoCustomerDTO.Address,
                City = createCargoCustomerDTO.City,
                District = createCargoCustomerDTO.District,
                Email = createCargoCustomerDTO.Email,
                Phone = createCargoCustomerDTO.Phone,
                LastName = createCargoCustomerDTO.LastName,
                Name = createCargoCustomerDTO.Name,
                UserId = createCargoCustomerDTO.UserId
            };
            _cargoCustomerService.TInsert(createValue);
            return Ok("Created Successfully");
        }

        [HttpDelete]
        public IActionResult RemoveCargoCustomer(int id)
        {
            _cargoCustomerService.TDelete(id);
            return Ok("Deleted Successfully");
        }

        [HttpGet("{id}")]
        public IActionResult GetCargoCustomerById(int id)
        {
            var value = _cargoCustomerService.TGetById(id);
            return Ok(value);
        }

        [HttpPut]
        public IActionResult UpdateCargoCustomer(UpdateCargoCustomerDTO updateCargoCustomerDTO)
        {
            CargoCustomer updateValue = new CargoCustomer()
            {
                CargoCustomerId = updateCargoCustomerDTO.CargoCustomerId,
                Address = updateCargoCustomerDTO.Address,
                City = updateCargoCustomerDTO.City,
                District = updateCargoCustomerDTO.District,
                Email = updateCargoCustomerDTO.Email,
                Phone = updateCargoCustomerDTO.Phone,
                LastName = updateCargoCustomerDTO.LastName,
                Name = updateCargoCustomerDTO.Name,
                UserId = updateCargoCustomerDTO.UserId
            };
            _cargoCustomerService.TUpdate(updateValue);
            return Ok("Updated Successfully");
        }
    }
}
