using MicroMultiBusiness.Cargo.BusinessLayer.Abstract;
using MicroMultiBusiness.Cargo.DTOLayer.DTOs.CargoOperationDTOs;
using MicroMultiBusiness.Cargo.EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MicroMultiBusiness.Cargo.WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoOperationsController : ControllerBase
    {
        private readonly ICargoOperationService _cargoOperationService;

        public CargoOperationsController(ICargoOperationService cargoOperationService)
        {
            _cargoOperationService = cargoOperationService;
        }

        [HttpGet]
        public IActionResult CargoOperationList()
        {
            var valuesList = _cargoOperationService.TGetAll();
            return Ok(valuesList);
        }

        [HttpPost]
        public IActionResult CreateCargoOperation(CreateCargoOperationDTO createCargoOperationDTO)
        {
            CargoOperation createValue = new CargoOperation()
            {
                Barcode = createCargoOperationDTO.Barcode,
                Description = createCargoOperationDTO.Description,
                OperationDate = createCargoOperationDTO.OperationDate
            };
            _cargoOperationService.TInsert(createValue);
            return Ok("Created Successfully");
        }

        [HttpDelete]
        public IActionResult RemoveCargoOperation(int id)
        {
            _cargoOperationService.TDelete(id);
            return Ok("Deleted Successfully");
        }

        [HttpGet("{id}")]
        public IActionResult GetCargoOperationById(int id)
        {
            var value = _cargoOperationService.TGetById(id);
            return Ok(value);
        }

        [HttpPut]
        public IActionResult UpdateCargoOperation(UpdateCargoOperationDTO updateCargoOperationDTO)
        {
            CargoOperation updateValue = new CargoOperation()
            { 
                CargoOperationId = updateCargoOperationDTO.CargoOperationId,
                Barcode = updateCargoOperationDTO.Barcode,
                Description = updateCargoOperationDTO.Description,
                OperationDate = updateCargoOperationDTO.OperationDate
            };
            _cargoOperationService.TUpdate(updateValue);
            return Ok("Updated Successfully");
        }
    }
}
