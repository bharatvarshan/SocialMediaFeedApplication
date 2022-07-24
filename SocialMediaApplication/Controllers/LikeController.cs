using SocialMediaApplication.Models;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authorization;

namespace SocialMediaApplication.Controllers
{
    [Route("api/[controller]"), Authorize(Roles = "1")]
    [ApiController]
    public class LikeController : ControllerBase
    {
        private readonly socialfeeddbContext _context;
        public LikeController(socialfeeddbContext context)
        {
            _context = context;
        }

        [HttpPost]
        [Route("[Action]/{feedId}")]
        public async Task<ActionResult<Like>> LikeFeed(int feedId)
        {

            var userId = decode();

            _context.Likes.Add(new Like
            {
                UserLiked = userId,
                FeedLiked = feedId
            })

         ;
            await _context.SaveChangesAsync();
            return Ok(new { msg = "User "+ userId + " Liked Feed " + feedId +" Successfully" });
        }


        [HttpDelete]
        [Route("[Action]/{feedId}")]
        public async Task<ActionResult<Like>> UnlikeFeed( int feedId)
        {

            var userId = decode();
            try
            {
                var feed = _context.Likes.Where(e => e.FeedLiked == feedId && e.UserLiked == userId).SingleOrDefault();
                _context.Likes.Remove(feed);
                _context.SaveChanges();
                return Ok(new { msg = "User " + userId + " Unliked Feed " + feedId + " Successfully" });
            }
            catch (Exception ex)
            {
                return BadRequest("Exception occurred: " + ex);
            }
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
