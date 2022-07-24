using SocialMediaApplication.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.IdentityModel.Tokens.Jwt;

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
            var userId = decode();

            _context.Comments.Add(new Comment
            {
                CommentedBy = userId,
                Comment1 = comment.Comment1,
                CommentedFeed = comment.CommentedFeed
            });

            await _context.SaveChangesAsync();
            return Ok(new { msg = "Commented Successfully" });
        }

        private int decode()
        {
            var handler = new JwtSecurityTokenHandler();
            string authHeader = Request.Headers["Authorization"];
            authHeader = authHeader.Replace("bearer ", "");
            var jsonToken = handler.ReadToken(authHeader);
            var tokenS = handler.ReadToken(authHeader) as JwtSecurityToken;
            var id = tokenS.Claims.First(claim => claim.Type == "Id").Value;
            Console.WriteLine("id", id);
            return Convert.ToInt32(id);
        }

    }
}
