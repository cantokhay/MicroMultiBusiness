using MicroMultiBusiness.DTOLayer.CatalogDTOs.CategoryDTOs;

namespace MicroMultiBusiness.WebUI.Services.CatalogServices.CategoryServices
{
    public interface ICategoryService
    {
        Task<List<ResultCategoryDTO>> GetAllCategoriesAsync();
        Task CreateCategoryAsync(CreateCategoryDTO createCategoryDTO);
        Task UpdateCategoryAsync(UpdateCategoryDTO updateCategoryDTO);
        Task DeleteCategoryAsync(string id);
        Task<GetByIdCategoryDTO> GetByIdCategoryAsync(string id);
    }
}
