using System.Text;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.Dtos.ProductDtos;

namespace SignalRWebUI.Controllers
{
	public class ProductController : Controller
	{
		private readonly IHttpClientFactory _clientFactory;

		public ProductController(IHttpClientFactory clientFactory)
		{
			_clientFactory = clientFactory;
		}
		public async Task<IActionResult> Index()
		{

			var client = _clientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7062/api/Product/ProductListWithCategory");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultProductDto>>(jsonData);
				return View(values);
			}
			return View();
		}
		[HttpGet]
		public IActionResult CreateProduct()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> CreateCategory(CreateProductDto createProductDto)
		{
			createProductDto.ProductStatus = true;
			var client = _clientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(createProductDto);
			StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var responseMessage = await client.PostAsync("https://localhost:7062/api/Product", content);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View();
		}
		public async Task<IActionResult> DeleteProduct(int id)
		{
			var client = _clientFactory.CreateClient();
			var responseMessage = await client.DeleteAsync($"https://localhost:7062/api/Product/{id}");
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View();
		}
		public async Task<IActionResult> UpdateProduct(int id)
		{
			var client = _clientFactory.CreateClient();
			var responseMessage = await client.GetAsync($"https://localhost:7062/api/Product/{id}");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<UpdateProductDto>(jsonData);
				return View(values);
			}
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> UpdateCategory(UpdateProductDto updateProductDto)
		{
			var client = _clientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(updateProductDto);
			StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var responseMessage = await client.PutAsync("https://localhost:7062/api/Product", content);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View();
		}
	}
}
