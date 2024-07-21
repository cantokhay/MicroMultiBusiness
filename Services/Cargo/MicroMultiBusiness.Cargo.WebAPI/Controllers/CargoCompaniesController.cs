using MicroMultiBusiness.Cargo.BusinessLayer.Abstract;
using MicroMultiBusiness.Cargo.DTOLayer.DTOs.CargoCompanyDTOs;
using MicroMultiBusiness.Cargo.EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MicroMultiBusiness.Cargo.WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoCompaniesController : ControllerBase
    {
        private readonly ICargoCompanyService _cargoCompanyService;

        public CargoCompaniesController(ICargoCompanyService cargoCompanyService)
        {
            _cargoCompanyService = cargoCompanyService;
        }

        [HttpGet]
        public IActionResult CargoCompanyList()
        {
            var valuesList = _cargoCompanyService.TGetAll();
            return Ok(valuesList);
        }

        [HttpPost]
        public IActionResult CreateCargoCompany(CreateCargoCompanyDTO createCargoCompanyDTO)
        {
            CargoCompany createValue = new CargoCompany() 
            { 
                CargoCompanyName = createCargoCompanyDTO.CargoCompanyName
            };
            _cargoCompanyService.TInsert(createValue);
            return Ok("Created Successfully");
        }

        [HttpDelete]
        public IActionResult RemoveCargoCompany(int id)
        {
            _cargoCompanyService.TDelete(id);
            return Ok("Deleted Successfully");
        }

        [HttpGet("{id}")]
        public IActionResult GetCargoCompanyById(int id)
        {
            var value = _cargoCompanyService.TGetById(id);
            return Ok(value);
        }

        [HttpPut]
        public IActionResult UpdateCargoCompany(UpdateCargoCompanyDTO updateCargoCompanyDTO)
        {
            CargoCompany updateValue = new CargoCompany()
            {
                CargoCompanyId = updateCargoCompanyDTO.CargoCompanyId,
                CargoCompanyName = updateCargoCompanyDTO.CargoCompanyName
            };
            _cargoCompanyService.TUpdate(updateValue);
            return Ok("Updated Successfully");
        }
    }
}
