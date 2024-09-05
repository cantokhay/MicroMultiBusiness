using MicroMultiBusiness.DTOLayer.CatalogDTOs.AboutDTOs;

namespace MicroMultiBusiness.WebUI.Services.CatalogServices.AboutServices
{
    public interface IAboutService
    {
        Task<List<ResultAboutDTO>> GetAllAboutsAsync();
        Task CreateAboutAsync(CreateAboutDTO createAboutDTO);
        Task UpdateAboutAsync(UpdateAboutDTO updateAboutDTO);
        Task DeleteAboutAsync(string id);
        Task<UpdateAboutDTO> GetByIdAboutAsync(string id);
    }
}
