using MicroMultiBusiness.DTOLayer.CommentDTOs;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace MicroMultiBusiness.WebUI.Controllers
{
    public class ProductListController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ProductListController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public IActionResult Index(string id)
        {
            ViewBag.i = id;
            return View();
        }

        public IActionResult ProductDetail(string id)
        {
            ViewBag.x = id;
            return View();
        }

        //[HttpGet]
        //public async Task<PartialViewResult> AddComment(string productId)
        //{
        //    var client = _httpClientFactory.CreateClient();
        //    var response = await client.GetAsync("http://localhost:7088/api/Comments/CommentListByProductId?productId=" + productId);
        //    if (response.IsSuccessStatusCode)
        //    {
        //        var jsonData = await response.Content.ReadAsStringAsync();
        //        var valuesList = JsonConvert.DeserializeObject<List<ResultCommentDTO>>(jsonData);
        //        return PartialView(valuesList);
        //    }
        //    return PartialView();
        //}

        //[HttpPost]
        //public IActionResult AddComment(CreateCommentDTO createCommentDTO)
        //{
        //    return RedirectToAction("Index", "Default");
        //}

        [HttpGet]
        public PartialViewResult AddComment()
        {
            return PartialView();
        }

        [HttpPost]
        public async Task<IActionResult> AddComment(CreateCommentDTO createCommentDTO)
        {
            createCommentDTO.ImageURL = "https://via.placeholder.com/150";
            createCommentDTO.Rating = 5;
            createCommentDTO.CreatedDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            createCommentDTO.Status = false;
            createCommentDTO.ProductId = "66a01f59933b2e01bd762a9c";
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createCommentDTO);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("http://localhost:7088/api/Comments", content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Default");
            }
            return View();
        }
    }
}
