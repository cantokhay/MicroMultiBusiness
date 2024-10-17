using MicroMultiBusiness.RapidAPIWebUI.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace MicroMultiBusiness.RapidAPIWebUI.Controllers
{
    public class ECommerceController : Controller
    {
        public async Task<IActionResult> ECommerceList()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://real-time-product-search.p.rapidapi.com/search?q=Nike%20shoes&country=tr&language=en&page=1&limit=30&sort_by=BEST_MATCH&min_rating=ANY"),
                Headers =
                {
                    { "x-rapidapi-key", "56eeaae0a2msh1f5a78362b65e64p1c49efjsn933601bf2799" },
                    { "x-rapidapi-host", "real-time-product-search.p.rapidapi.com" },
                },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var productsList = JsonConvert.DeserializeObject<ECommerceViewModel>(body);

                return View(productsList.data.ToList());
            }
        }
    }
}
