using MicroMultiBusiness.Catalog.DTOs.ProductDTOs;

namespace MicroMultiBusiness.Catalog.Services.ProductServices
{
    public interface IProductService
    {
        Task<List<ResultProductDTO>> GetAllProductsAsync();
        Task CreateProductAsync(CreateProductDTO createProductDTO);
        Task UpdateProductAsync(UpdateProductDTO updateProductDTO);
        Task DeleteProductAsync(string id);
        Task<GetByIdProductDTO> GetByIdProductAsync(string id);
        Task<List<ResultProductWithCategoryDTO>> GetAllProductsWithCategoryAsync();
    }
}
