using MicroMultiBusiness.RapidAPIWebUI.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace MicroMultiBusiness.RapidAPIWebUI.Controllers
{
    public class DefaultController : Controller
    {
        public async Task<IActionResult> Scoreboard()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://livescore6.p.rapidapi.com/matches/v2/get-scoreboard?Category=soccer&Eid=1019778"),
                Headers =
                        {
                            { "x-rapidapi-key", "56eeaae0a2msh1f5a78362b65e64p1c49efjsn933601bf2799" },
                            { "x-rapidapi-host", "livescore6.p.rapidapi.com" },
                        },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                ScoreboardViewModel? scoreboard = JsonConvert.DeserializeObject<ScoreboardViewModel>(body);

                return View(scoreboard);
            }
        }

        public async Task<IActionResult> Exchange()
        {
            var usdClient = new HttpClient();
            var usdRequest = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://binance43.p.rapidapi.com/avgPrice?symbol=USDTTRY"),
                Headers =
                {
                    { "x-rapidapi-key", "56eeaae0a2msh1f5a78362b65e64p1c49efjsn933601bf2799" },
                    { "x-rapidapi-host", "binance43.p.rapidapi.com" },
                },
            };
            using (var usdResponse = await usdClient.SendAsync(usdRequest))
            {
                usdResponse.EnsureSuccessStatusCode();
                var usdBody = await usdResponse.Content.ReadAsStringAsync();
                var usdValue= JsonConvert.DeserializeObject<ExchangeViewModel.Rootobject>(usdBody);
                ViewBag.USDexchangeRate = usdValue.price;
            }
            var btcClient = new HttpClient();
            var btcRequest = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://binance43.p.rapidapi.com/avgPrice?symbol=BTCUSDT"),
                Headers =
                {
                    { "x-rapidapi-key", "56eeaae0a2msh1f5a78362b65e64p1c49efjsn933601bf2799" },
                    { "x-rapidapi-host", "binance43.p.rapidapi.com" },
                },
            };
            using (var btcResponse = await btcClient.SendAsync(btcRequest))
            {
                btcResponse.EnsureSuccessStatusCode();
                var btcBody = await btcResponse.Content.ReadAsStringAsync();
                var btcvalue = JsonConvert.DeserializeObject<ExchangeViewModel.Rootobject>(btcBody);
                ViewBag.BTCexchangeRate = btcvalue.price;
            }
            return View();
        }
    }
}

