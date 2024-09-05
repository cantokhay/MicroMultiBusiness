using MicroMultiBusiness.DTOLayer.CatalogDTOs.ProductDTOs;

namespace MicroMultiBusiness.WebUI.Services.CatalogServices.ProductServices
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _httpClient;

        public ProductService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateProductAsync(CreateProductDTO createProductDTO)
        {
            await _httpClient.PostAsJsonAsync<CreateProductDTO>(requestUri: "products", createProductDTO);
        }

        public async Task DeleteProductAsync(string id)
        {
            await _httpClient.DeleteAsync("products?id=" + id);
        }

        public async Task<List<ResultProductDTO>> GetAllProductsAsync()
        {
            var response = await _httpClient.GetAsync("products");
            var valuesList = await response.Content.ReadFromJsonAsync<List<ResultProductDTO>>();
            return valuesList;
        }

        public async Task<List<ResultProductWtihCategoryDTO>> GetAllProductsWithCategoryAsync()
        {
            var response = await _httpClient.GetAsync("products");
            var valuesList = await response.Content.ReadFromJsonAsync<List<ResultProductWtihCategoryDTO>>();
            return valuesList;
        }

        public async Task<UpdateProductDTO> GetByIdProductAsync(string id)
        {
            var response = await _httpClient.GetAsync("products/" + id);
            var value = await response.Content.ReadFromJsonAsync<UpdateProductDTO>();
            return value;
        }

        public async Task<List<ResultProductWtihCategoryDTO>> GetProductsWithCategoryByCategoryIdAsync(string categoryId)
        {
            var response = await _httpClient.GetAsync("products/productlistwithcategorybycategoryid/"+ categoryId);
            var valuesList = await response.Content.ReadFromJsonAsync<List<ResultProductWtihCategoryDTO>>();
            return valuesList;
        }

        public async Task UpdateProductAsync(UpdateProductDTO updateProductDTO)
        {
            await _httpClient.PutAsJsonAsync<UpdateProductDTO>("products", updateProductDTO);
        }
    }
}
