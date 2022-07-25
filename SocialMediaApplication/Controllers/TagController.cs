using SocialMediaApplication.Models;
using Microsoft.AspNetCore.Mvc;
using SocialMediaApplication.Services;

namespace SocialMediaApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagController : ControllerBase
    {
        private readonly TagService _service;
        public TagController(TagService service)
        {
            _service = service;
        }

        [HttpPost]
        [Route("[Action]/{userId}/{feedId}")]
        public async Task<IActionResult> TagFeed(int userId, int feedId)
        {

            var tagObj = _service.Tag(userId, feedId);
            if (tagObj != null)
            {
                return Ok(tagObj);
            }
            return BadRequest(new { msg = "Unable to Tag feed" });
        }

        


    }
}
