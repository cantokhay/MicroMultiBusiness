using MicroMultiBusiness.DTOLayer.CatalogDTOs.BrandDTOs;

namespace MicroMultiBusiness.WebUI.Services.CatalogServices.BrandServices
{
    public interface IBrandService
    {
        Task<List<ResultBrandDTO>> GetAllBrandsAsync();
        Task CreateBrandAsync(CreateBrandDTO createBrandDTO);
        Task UpdateBrandAsync(UpdateBrandDTO updateBrandDTO);
        Task DeleteBrandAsync(string id);
        Task<UpdateBrandDTO> GetByIdBrandAsync(string id);
    }
}
