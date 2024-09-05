using MicroMultiBusiness.DTOLayer.CommentDTOs;
using MicroMultiBusiness.WebUI.Services.CommentServices;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace MicroMultiBusiness.WebUI.ViewComponents.ProductDetailViewComponent
{
    public class _ProductDetailReviewComponentPartial : ViewComponent
    {
        //private readonly IHttpClientFactory _httpClientFactory;
        private readonly ICommentService _commentService;

        public _ProductDetailReviewComponentPartial(ICommentService commentService)
        {
            //_httpClientFactory = httpClientFactory;
            _commentService = commentService;
        }

        public async Task<IViewComponentResult> InvokeAsync(string id)
        {
            //var client = _httpClientFactory.CreateClient();
            //var response = await client.GetAsync("http://localhost:7088/api/Comments/CommentListByProductId?productId="+ productId);
            //if (response.IsSuccessStatusCode)
            //{
            //    var jsonData = await response.Content.ReadAsStringAsync();
            //    var valuesList = JsonConvert.DeserializeObject<List<ResultCommentDTO>>(jsonData);
            //    return View(valuesList);
            //}
            //return View();

            var valuesList = await _commentService.CommentListByProductId(id);
            
            return View(valuesList);
        }
    }
}
