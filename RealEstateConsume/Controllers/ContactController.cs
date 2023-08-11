using DTO.DTOs.CommenDTOs;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace RealEstateConsume.Controllers
{
    public class ContactController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ContactController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.username = HttpContext.Session.GetString("Username");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(CreateCommentDTO createCommentDTO)
        {
            var user = HttpContext.Session.GetString("Username");
            createCommentDTO.UserName = user;
            var client = _httpClientFactory.CreateClient();
            var JsonData = JsonConvert.SerializeObject(createCommentDTO);
            StringContent content = new StringContent(JsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7138/api/Comment", content);
            return View();
        }
    }
}
