using SocialMediaApplication.Models;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authorization;
using SocialMediaApplication.Services;

namespace SocialMediaApplication.Controllers
{
    //[Route("api/[controller]"), Authorize(Roles = "1")]
    [Route("api/[controller]")]
    [ApiController]
    public class LikeController : ControllerBase
    {
        private readonly LikeService _service;
        public LikeController(LikeService service)
        {
            _service = service;
        }

        [HttpPost]
        [Route("[Action]/{feedId}")]
        public async Task<IActionResult> LikeFeed(int feedId)
        {


            var userId = decode();

            var feedObj = _service.Like(feedId, userId);

            if(feedObj != null)
            {
                return Ok(feedObj);
            }
            return BadRequest(new {msg = "Unable to like feed"});
            
        }


        [HttpDelete]
        [Route("[Action]/{feedId}")]
        public async Task<IActionResult> UnlikeFeed( int feedId)
        {

            var userId = decode();


            var feed = await _service.Unlike(feedId, userId);
                if(feed != null)
                {
                    return Ok(feed);
                }
            return BadRequest(new { msg = "Unable to like feed" });

                
   
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
