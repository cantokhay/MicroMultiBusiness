using MicroMultiBusiness.DTOLayer.OrderDTOs.AddressDTOs;

namespace MicroMultiBusiness.WebUI.Services.OrderServices.AddressServices
{
    public interface IAddressService
    {
        //Task<List<ResultAddressDTO>> GetAllAddressesAsync();
        //Task<GetByIdAddressDTO> GetAddressByIdAsync(string id);
        Task<CreateAddressDTO> CreateAddressAsync(CreateAddressDTO address);
        //Task<UpdateAddressDTO> UpdateAddressAsync(UpdateAddressDTO address);
        //Task<CreateAddressDTO> DeleteAddressAsync(string id);
    }
}
