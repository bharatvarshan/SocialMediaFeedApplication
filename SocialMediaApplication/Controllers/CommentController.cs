using SocialMediaApplication.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace SocialMediaApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly socialfeeddbContext _context;
        public CommentController(socialfeeddbContext context)
        {
            _context = context;
        }

        [HttpPost]
        [Route("[Action]")]
        public async Task<ActionResult<Comment>> CommentFeed([FromBody] Comment comment)
        {
            _context.Comments.Add(comment);

            await _context.SaveChangesAsync();
            return Ok(new { msg = "Commented Successfully" });
        }



    }
}
