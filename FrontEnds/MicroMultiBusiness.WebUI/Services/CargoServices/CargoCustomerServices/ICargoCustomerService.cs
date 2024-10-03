using MicroMultiBusiness.DTOLayer.CargoDTOs.CargoCustomerDTOs;

namespace MicroMultiBusiness.WebUI.Services.CargoServices.CargoCustomerServices
{
    public interface ICargoCustomerService
    {
        Task<GetCargoCustomerByIdDTO> GetCargoCustomerDetailByIdAsync(string id);
    }
}
