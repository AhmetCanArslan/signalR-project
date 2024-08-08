using System.Text;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace SignalRWebUI.Dtos.ContactDtos
{
	public class ContactController : Controller
	{
		private readonly IHttpClientFactory _clientFactory;

		public ContactController(IHttpClientFactory clientFactory)
		{
			_clientFactory = clientFactory;
		}

		public async Task<IActionResult> Index()
		{

			var client = _clientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7062/api/Contact");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultContactDto>>(jsonData);
				return View(values);
			}
			return View();
		}
		[HttpGet]
		public IActionResult CreateContact()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> CreateContact(CreateContactDto createContactDto)
		{
			var client = _clientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(createContactDto);
			StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var responseMessage = await client.PostAsync("https://localhost:7062/api/Contact", content);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View();
		}
		public async Task<IActionResult> DeleteContact(int id)
		{
			var client = _clientFactory.CreateClient();
			var responseMessage = await client.DeleteAsync($"https://localhost:7062/api/Contact/{id}");
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View();
		}
		[HttpGet]
		public async Task<IActionResult> UpdateContact(int id)
		{
			var client = _clientFactory.CreateClient();
			var responseMessage = await client.GetAsync($"https://localhost:7062/api/Contact/{id}");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<UpdateContactDto>(jsonData);
				return View(values);
			}
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> UpdateContact(UpdateContactDto updateContactDto)
		{
			var client = _clientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(updateContactDto);
			StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var responseMessage = await client.PutAsync("https://localhost:7062/api/Contact", content);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View();
		}
	}
}
