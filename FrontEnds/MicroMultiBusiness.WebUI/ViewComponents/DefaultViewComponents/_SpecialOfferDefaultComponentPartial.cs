﻿using MicroMultiBusiness.DTOLayer.CatalogDTOs.SpecialOfferDTOs;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace MicroMultiBusiness.WebUI.ViewComponents.DefaultViewComponents
{
    public class _SpecialOfferDefaultComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _SpecialOfferDefaultComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("http://localhost:7070/api/SpecialOffers");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var valuesList = JsonConvert.DeserializeObject<List<ResultSpecialOfferDTO>>(jsonData);
                return View(valuesList);
            }
            return View();
        }
    }
}
