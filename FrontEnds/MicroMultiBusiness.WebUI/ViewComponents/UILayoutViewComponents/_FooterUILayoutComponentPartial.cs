﻿using MicroMultiBusiness.DTOLayer.CatalogDTOs.AboutDTOs;
using MicroMultiBusiness.WebUI.Services.CatalogServices.AboutServices;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http.Headers;

namespace MicroMultiBusiness.WebUI.ViewComponents.UILayoutViewComponents
{
    public class _FooterUILayoutComponentPartial : ViewComponent
    {
        //private readonly IHttpClientFactory _httpClientFactory;
        private readonly IAboutService _aboutService;

        public _FooterUILayoutComponentPartial(IAboutService aboutService)
        {
            //_httpClientFactory = httpClientFactory;
            _aboutService = aboutService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            //string token = "";
            //using (var httpClient = new HttpClient())
            //{
            //    var request = new HttpRequestMessage
            //    {
            //        RequestUri = new Uri("http://localhost:5001/connect/token"),
            //        Method = HttpMethod.Post,
            //        Content = new FormUrlEncodedContent(new Dictionary<string, string>
            //        {
            //            {"client_id" , "MicroMultiBusinessVisitorId" },
            //            {"client_secret", "MicroMultiBusinessSecretKey" },
            //            {"grant_type", "client_credentials" }
            //        })
            //    };

            //    using (var response = await httpClient.SendAsync(request))
            //    {
            //        if (response.IsSuccessStatusCode)
            //        {
            //            var content = await response.Content.ReadAsStringAsync();
            //            var tokenResponse = JObject.Parse(content);
            //            token = tokenResponse["access_token"].ToString();
            //        }
            //    }
            //}

            //var client = _httpClientFactory.CreateClient();
            //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            //var responseMessage = await client.GetAsync("http://localhost:7070/api/Abouts");
            //if (responseMessage.IsSuccessStatusCode)
            //{
            //    var jsonData = await responseMessage.Content.ReadAsStringAsync();
            //    var values = JsonConvert.DeserializeObject<List<ResultAboutDTO>>(jsonData);
            //    return View(values);
            //}
            //return View();

            var values = await _aboutService.GetAllAboutsAsync();
            return View(values);
        }
    }
}
