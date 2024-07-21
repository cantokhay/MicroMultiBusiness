using MicroMultiBusiness.Cargo.BusinessLayer.Abstract;
using MicroMultiBusiness.Cargo.DTOLayer.DTOs.CargoDetailDTOs;
using MicroMultiBusiness.Cargo.EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MicroMultiBusiness.Cargo.WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoDetailsController : ControllerBase
    {
        private readonly ICargoDetailService _cargoDetailService;

        public CargoDetailsController(ICargoDetailService cargoDetailService)
        {
            _cargoDetailService = cargoDetailService;
        }

        [HttpGet]
        public IActionResult CargoDetailList()
        {
            var valuesList = _cargoDetailService.TGetAll();
            return Ok(valuesList);
        }

        [HttpPost]
        public IActionResult CreateCargoDetail(CreateCargoDetailDTO createCargoDetailDTO)
        {
            CargoDetail createValue = new CargoDetail()
            {
                Barcode = createCargoDetailDTO.Barcode,
                CargoCompanyId = createCargoDetailDTO.CargoCompanyId,
                ReceiverCustomer = createCargoDetailDTO.ReceiverCustomer,
                SenderCustomer = createCargoDetailDTO.SenderCustomer
            };
            _cargoDetailService.TInsert(createValue);
            return Ok("Created Successfully");
        }

        [HttpDelete]
        public IActionResult RemoveCargoDetail(int id)
        {
            _cargoDetailService.TDelete(id);
            return Ok("Deleted Successfully");
        }

        [HttpGet("{id}")]
        public IActionResult GetCargoDetailById(int id)
        {
            var value = _cargoDetailService.TGetById(id);
            return Ok(value);
        }

        [HttpPut]
        public IActionResult UpdateCargoDetail(UpdateCargoDetailDTO updateCargoDetailDTO)
        {
            CargoDetail updateValue = new CargoDetail()
            {
                CargoDetailId = updateCargoDetailDTO.CargoDetailId,
                Barcode = updateCargoDetailDTO.Barcode,
                CargoCompanyId = updateCargoDetailDTO.CargoCompanyId,
                ReceiverCustomer = updateCargoDetailDTO.ReceiverCustomer,
                SenderCustomer = updateCargoDetailDTO.SenderCustomer
            };
            _cargoDetailService.TUpdate(updateValue);
            return Ok("Updated Successfully");
        }
    }
}
