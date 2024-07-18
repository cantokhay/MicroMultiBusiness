using MicroMultiBusiness.Catalog.DTOs.CategoryDTOs;

namespace MicroMultiBusiness.Catalog.Services.CategoryServices
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
