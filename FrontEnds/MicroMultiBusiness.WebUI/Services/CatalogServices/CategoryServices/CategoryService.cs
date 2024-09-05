using MicroMultiBusiness.DTOLayer.CatalogDTOs.CategoryDTOs;

namespace MicroMultiBusiness.WebUI.Services.CatalogServices.CategoryServices
{
    public class CategoryService : ICategoryService
    {
        private readonly HttpClient _httpClient;

        public CategoryService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateCategoryAsync(CreateCategoryDTO createCategoryDTO)
        {
            await _httpClient.PostAsJsonAsync<CreateCategoryDTO>("categories", createCategoryDTO);
        }

        public async Task DeleteCategoryAsync(string id)
        {
            await _httpClient.DeleteAsync("categories?id=" + id);
        }

        public async Task<List<ResultCategoryDTO>> GetAllCategoriesAsync()
        {
            var response = await _httpClient.GetAsync("categories");
            var valuesList = await response.Content.ReadFromJsonAsync<List<ResultCategoryDTO>>();
            return valuesList;
        }

        public async Task<UpdateCategoryDTO> GetByIdCategoryAsync(string id)
        {
            var response = await _httpClient.GetAsync("categories/" + id);
            var value = await response.Content.ReadFromJsonAsync<UpdateCategoryDTO>();
            return value;
        }

        public async Task UpdateCategoryAsync(UpdateCategoryDTO updateCategoryDTO)
        {
            await _httpClient.PutAsJsonAsync<UpdateCategoryDTO>("categories", updateCategoryDTO);
        }
    }
}
