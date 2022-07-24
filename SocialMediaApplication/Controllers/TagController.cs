using SocialMediaApplication.Models;
using Microsoft.AspNetCore.Mvc;

namespace SocialMediaApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagController : ControllerBase
    {
        private readonly socialfeeddbContext _context;
        public TagController(socialfeeddbContext context)
        {
            _context = context;
        }

        [HttpPost]
        [Route("[Action]/{userId}/{feedId}")]
        public async Task<ActionResult<Tag>> TagFeed(int userId, int feedId)
        {
            _context.Tags.Add(new Tag
            {
                FeedTagged = feedId,
                UserTagged = userId
            })

         ;
            await _context.SaveChangesAsync();
            return Ok(new { msg = "User Tagged Successfully" });
        }


        


    }
}
