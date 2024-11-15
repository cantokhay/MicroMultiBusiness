﻿using MicroMultiBusiness.Catalog.DTOs.AboutDTOs;

namespace MicroMultiBusiness.Catalog.Services.AboutServices
{
    public interface IAboutService
    {
        Task<List<ResultAboutDTO>> GetAllAboutsAsync();
        Task CreateAboutAsync(CreateAboutDTO createAboutDTO);
        Task UpdateAboutAsync(UpdateAboutDTO updateAboutDTO);
        Task DeleteAboutAsync(string id);
        Task<GetByIdAboutDTO> GetByIdAboutAsync(string id);
    }
}
