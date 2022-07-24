using SocialMediaApplication.Models;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;

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
