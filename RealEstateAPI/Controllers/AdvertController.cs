using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RealEstateAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdvertController : ControllerBase
    {
        private readonly IAdvertService _advertService;

        public AdvertController(IAdvertService advertService)
        {
            _advertService = advertService;
        }

        [HttpGet]
        public IActionResult AnnouncementList()
        {
            var values = _advertService.TGetList();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult AddAnnouncement(Advert advert)
        {
            _advertService.TInsert(advert);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAnnouncement(string id)
        {
            var value = _advertService.TGetByID(id);
            _advertService.TDelete(value);
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetAnnouncement(string id)
        {
            var value = _advertService.TGetByID(id);
            return Ok(value);
        }
        [HttpPut]
        public IActionResult UpdateAnnouncement(Advert advert)
        {
            _advertService.TUpdate(advert);
            return Ok();
        }
    }
}
