﻿using MicroMultiBusiness.DTOLayer.CatalogDTOs.FeatureDTOs;
using MicroMultiBusiness.WebUI.Services.CatalogServices.FeatureServices;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace MicroMultiBusiness.WebUI.ViewComponents.DefaultViewComponents
{
    public class _FeatureDefaultComponentPartial : ViewComponent
    {
        //private readonly IHttpClientFactory _httpClientFactory;
        private readonly IFeatureService _featureService;

        public _FeatureDefaultComponentPartial(IFeatureService featureService)
        {
            //_httpClientFactory = httpClientFactory;
            _featureService = featureService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            //var client = _httpClientFactory.CreateClient();
            //var response = await client.GetAsync("http://localhost:7070/api/Features");
            //if (response.IsSuccessStatusCode)
            //{
            //    var jsonData = await response.Content.ReadAsStringAsync();
            //    var valuesList = JsonConvert.DeserializeObject<List<ResultFeatureDTO>>(jsonData);
            //    return View(valuesList);
            //}
            //return View();

            var valuesList = await _featureService.GetAllFeaturesAsync();
            return View(valuesList);
        }
    }
}
