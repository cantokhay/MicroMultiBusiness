using MicroMultiBusiness.DTOLayer.CargoDTOs.CargoCompanyDTOs;

namespace MicroMultiBusiness.WebUI.Services.CargoServices.CargoCompanyServices
{
    public interface ICargoCompanyService
    {
        Task<List<ResultCargoCompanyDTO>> GetAllCargoCompaniesAsync();
        Task CreateCargoCompanyAsync(CreateCargoCompanyDTO createCargoCompanyDTO);
        Task UpdateCargoCompanyAsync(UpdateCargoCompanyDTO updateCargoCompanyDTO);
        Task DeleteCargoCompanyAsync(int id);
        Task<UpdateCargoCompanyDTO> GetByIdCargoCompanyAsync(int id);
    }
}
