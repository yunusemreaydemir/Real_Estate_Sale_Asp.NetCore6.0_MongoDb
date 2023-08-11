using DTO.DTOs.UserDTOs;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace RealEstateConsume.Controllers
{
    public class LoginController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public LoginController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(ResultUserDTO resultUserDTO)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7138/api/User");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultUserDTO>>(jsonData);
                var result = values.FirstOrDefault(x => x.Email == resultUserDTO.Email && x.Password == resultUserDTO.Password);
                if (result != null)
                {
                    var user = result.UserName;
                    HttpContext.Session.SetString("Username", result.UserName);
                    return RedirectToAction("Index", "Default");
                }
            }
            return View();

        }
    }
}
