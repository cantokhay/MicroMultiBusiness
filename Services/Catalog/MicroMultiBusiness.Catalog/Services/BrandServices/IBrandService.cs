using MicroMultiBusiness.Catalog.DTOs.BrandDTOs;

namespace MicroMultiBusiness.Catalog.Services.BrandServices
{
    public interface IBrandService
    {
        Task<List<ResultBrandDTO>> GetAllBrandsAsync();
        Task CreateBrandAsync(CreateBrandDTO createBrandDTO);
        Task UpdateBrandAsync(UpdateBrandDTO updateBrandDTO);
        Task DeleteBrandAsync(string id);
        Task<GetByIdBrandDTO> GetByIdBrandAsync(string id);
    }
}
