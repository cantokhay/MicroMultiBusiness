﻿using MicroMultiBusiness.Catalog.DTOs.ProductImageDTOs;

namespace MicroMultiBusiness.Catalog.Services.ProductImageServices
{
    public interface IProductImageService
    {
        Task<List<ResultProductImageDTO>> GetAllProductImagesAsync();
        Task CreateProductImageAsync(CreateProductImageDTO createProductImageDTO);
        Task UpdateProductImageAsync(UpdateProductImageDTO updateProductImageDTO);
        Task DeleteProductImageAsync(string id);
        Task<GetByIdProductImageDTO> GetByIdProductImageAsync(string id);
        Task<GetByIdProductImageDTO> GetAllProductImagesByProductIdAsync(string id);
    }
}
