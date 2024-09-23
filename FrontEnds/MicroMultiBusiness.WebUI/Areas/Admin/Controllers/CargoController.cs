using MicroMultiBusiness.DTOLayer.CargoDTOs.CargoCompanyDTOs;
using MicroMultiBusiness.WebUI.Services.CargoServices.CargoCompanyServices;
using Microsoft.AspNetCore.Mvc;

namespace MicroMultiBusiness.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/Cargo")]
    public class CargoController : Controller
    {
        private readonly ICargoCompanyService _cargoCompanyService;

        public CargoController(ICargoCompanyService cargoCompanyService)
        {
            _cargoCompanyService = cargoCompanyService;
        }

        [Route("CargoCompaniesList")]
        public async Task<IActionResult> CargoCompaniesList()
        {
            CargoCompanyViewBagList();
            var valuesList = await _cargoCompanyService.GetAllCargoCompaniesAsync();
            return View(valuesList);
        }

        [HttpGet]
        [Route("CreateCargoCompany")]
        public IActionResult CreateCargoCompany()
        {
            CargoCompanyViewBagList();
            return View();
        }

        [HttpPost]
        [Route("CreateCargoCompany")]
        public async Task<IActionResult> CreateCargoCompany(CreateCargoCompanyDTO createCargoCompanyDTO)
        {
            CargoCompanyViewBagList();
            await _cargoCompanyService.CreateCargoCompanyAsync(createCargoCompanyDTO);
            return RedirectToAction("CargoCompaniesList", "Cargo", new { area = "Admin" });
        }

        [Route("DeleteCargoCompany/{id}")]
        public async Task<IActionResult> DeleteCargoCompany(int id)
        {
            CargoCompanyViewBagList();
            await _cargoCompanyService.DeleteCargoCompanyAsync(id);
            return RedirectToAction("CargoCompaniesList", "Cargo", new { area = "Admin" });
        }

        [HttpGet]
        [Route("UpdateCargoCompany/{id}")]
        public async Task<IActionResult> UpdateCargoCompany(int id)
        {
            CargoCompanyViewBagList();
            var cargoCompany = await _cargoCompanyService.GetByIdCargoCompanyAsync(id);
            return View(cargoCompany);
        }

        [HttpPost]
        [Route("UpdateCargoCompany/{id}")]
        public async Task<IActionResult> UpdateCargoCompany(UpdateCargoCompanyDTO updateCargoCompanyDTO)
        {
            CargoCompanyViewBagList();
            await _cargoCompanyService.UpdateCargoCompanyAsync(updateCargoCompanyDTO);
            return RedirectToAction("CargoCompaniesList", "Cargo", new { area = "Admin" });
        }

        private void CargoCompanyViewBagList()
        {
            ViewBag.v1 = "Home Page";
            ViewBag.v2 = "Cargo Companies";
            ViewBag.v3 = "Cargo Companies List";
            ViewBag.v0 = "Cargo Company operations";
        }
    }
}
