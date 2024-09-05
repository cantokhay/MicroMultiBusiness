using MicroMultiBusiness.DTOLayer.CatalogDTOs.ContactDTOs;

namespace MicroMultiBusiness.WebUI.Services.CatalogServices.ContactServices
{
    public interface IContactService
    {
        Task<List<ResultContactDTO>> GetAllContactsAsync();
        Task CreateContactAsync(CreateContactDTO createContactDTO);
        Task UpdateContactAsync(UpdateContactDTO updateContactDTO);
        Task DeleteContactAsync(string id);
        Task<UpdateContactDTO> GetByIdContactAsync(string id);
    }
}
