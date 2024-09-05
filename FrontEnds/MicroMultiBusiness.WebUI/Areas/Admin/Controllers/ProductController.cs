using MicroMultiBusiness.DTOLayer.CatalogDTOs.CategoryDTOs;
using MicroMultiBusiness.DTOLayer.CatalogDTOs.ProductDTOs;
using MicroMultiBusiness.WebUI.Services.CatalogServices.CategoryServices;
using MicroMultiBusiness.WebUI.Services.CatalogServices.ProductServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
//using Microsoft.AspNetCore.Authorization;
//using Newtonsoft.Json;
//using System.Text;

namespace MicroMultiBusiness.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    //[AllowAnonymous]
    [Route("Admin/Product")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;

        public ProductController(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            ProductViewBagList();

            //var client = _httpClientFactory.CreateClient();
            //var response = await client.GetAsync("http://localhost:7070/api/Products");
            //if (response.IsSuccessStatusCode)
            //{
            //    var jsonData = await response.Content.ReadAsStringAsync();
            //    var valuesList = JsonConvert.DeserializeObject<List<ResultProductDTO>>(jsonData);
            //    return View(valuesList);
            //}
            //return View();

            var valuesList = await _productService.GetAllProductsAsync();

            return View(valuesList);
        }

        [Route("ProductListWithCategory")]
        public async Task<IActionResult> ProductListWithCategory()
        {
            ProductViewBagList();

            //var client = _httpClientFactory.CreateClient();
            //var response = await client.GetAsync("http://localhost:7070/api/Products/ProductListWithCategory");
            //if (response.IsSuccessStatusCode)
            //{
            //    var jsonData = await response.Content.ReadAsStringAsync();
            //    var valuesList = JsonConvert.DeserializeObject<List<ResultProductWtihCategoryDTO>>(jsonData);
            //    return View(valuesList);
            //}
            return View();
        }

        [HttpGet]
        [Route("CreateProduct")]
        public async Task<IActionResult> CreateProduct()
        {
            ProductViewBagList();

            //var client = _httpClientFactory.CreateClient();
            //var response = await client.GetAsync("http://localhost:7070/api/Categories");
            //var jsonData = await response.Content.ReadAsStringAsync();
            //var valuesList = JsonConvert.DeserializeObject<List<ResultCategoryDTO>>(jsonData);

            var valuesList = await _categoryService.GetAllCategoriesAsync();
            List<SelectListItem> categoriesList = (from x in valuesList
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryId
                                                   }).ToList();
            ViewBag.CategoriesList = categoriesList;

            return View();
        }

        [HttpPost]
        [Route("CreateProduct")]
        public async Task<IActionResult> CreateProduct(CreateProductDTO createProductDTO)
        {
            //var client = _httpClientFactory.CreateClient();
            //var jsonData = JsonConvert.SerializeObject(createProductDTO);
            //StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            //var response = await client.PostAsync("http://localhost:7070/api/Products", content);
            //if (response.IsSuccessStatusCode)
            //{
            //    return RedirectToAction("Index", "Product", new { area = "Admin" });
            //}

            await _productService.CreateProductAsync(createProductDTO);

            return RedirectToAction("Index", "Product", new { area = "Admin" });
        }

        [Route("DeleteProduct/{id}")]
        public async Task<IActionResult> DeleteProduct(string id)
        {
            //var client = _httpClientFactory.CreateClient();
            //var response = await client.DeleteAsync("http://localhost:7070/api/Products?id=" + id);
            //if (response.IsSuccessStatusCode)
            //{
            //    return RedirectToAction("Index", "Product", new { area = "Admin" });
            //}
            //return View();

            await _productService.DeleteProductAsync(id);

            return RedirectToAction("Index", "Product", new { area = "Admin" });
        }

        [Route("UpdateProduct/{id}")]
        [HttpGet]
        public async Task<IActionResult> UpdateProduct(string id)
        {
            ProductViewBagList();

            //var client = _httpClientFactory.CreateClient();
            //var responseProduct = await client.GetAsync("http://localhost:7070/api/Products/" + id);
            //var responseCategory = await client.GetAsync("http://localhost:7070/api/Categories");
            //if (responseProduct.IsSuccessStatusCode)
            //{
            //    var jsonData = await responseProduct.Content.ReadAsStringAsync();
            //    var valueToUpdate = JsonConvert.DeserializeObject<UpdateProductDTO>(jsonData);
            //    var jsonDataCategory = await responseCategory.Content.ReadAsStringAsync();
            //    var valuesList = JsonConvert.DeserializeObject<List<ResultCategoryDTO>>(jsonDataCategory);
            //    List<SelectListItem> categoriesList = (from x in valuesList
            //                                           select new SelectListItem
            //                                           {
            //                                               Text = x.CategoryName,
            //                                               Value = x.CategoryId
            //                                           }).ToList();
            //    ViewBag.CategoriesList = categoriesList;
            //    return View(valueToUpdate);
            //}

            var valuesList = await _categoryService.GetAllCategoriesAsync();
            List<SelectListItem> categoriesList = (from x in valuesList
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryId
                                                   }).ToList();
            ViewBag.CategoriesList = categoriesList;

            var valueToUpdate = await _productService.GetByIdProductAsync(id);

            return View(valueToUpdate);
        }

        [Route("UpdateProduct/{id}")]
        [HttpPost]
        public async Task<IActionResult> UpdateProduct(UpdateProductDTO updateProductDTO)
        {
            //var client = _httpClientFactory.CreateClient();
            //var jsonData = JsonConvert.SerializeObject(updateProductDTO);
            //StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            //var response = await client.PutAsync("http://localhost:7070/api/Products", content);
            //if (response.IsSuccessStatusCode)
            //{
            //    return RedirectToAction("Index", "Product", new { area = "Admin" });
            //}
            //return View();

            await _productService.UpdateProductAsync(updateProductDTO);

            return RedirectToAction("Index", "Product", new { area = "Admin" });
        }

        private void ProductViewBagList()
        {
            ViewBag.v1 = "Home Page";
            ViewBag.v2 = "Products";
            ViewBag.v3 = "Products List";
            ViewBag.v0 = "Product operations";
        }
    }
}
