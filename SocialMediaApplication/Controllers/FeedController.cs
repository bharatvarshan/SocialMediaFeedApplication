using SocialMediaApplication.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using System.IdentityModel.Tokens.Jwt;

namespace SocialMediaApplication.Controllers
{
    [Route("api/[controller]"), Authorize(Roles = "1")]
    [ApiController]
    public class FeedController : ControllerBase
    {
        private readonly socialfeeddbContext _context;
        public FeedController(socialfeeddbContext context)
        {
            _context = context;
        }


        [HttpGet]
        [Route("[Action]")]
        public async Task<ActionResult<Feed>> GetFeed()
        {
            var userId = decode();

            if (_context?.Feeds == null)
            {
                return BadRequest(new { msg = "Please Login" });
            }

            var feed = await _context.Feeds.Where(x => x.PostedBy == userId).ToListAsync() ;

            if (feed == null)
            {
                return NotFound(new { msg = $"Feed not found for user id {userId}" });
            }

            return Ok(feed);
        }


        [HttpGet]
        [Route("[Action]")]
        public async Task<ActionResult<Object>> GetAllFeed()
        {
            if (_context?.Feeds == null)
            {
                return BadRequest(new { msg = "No Feed Available" });
            }

            var feed = await _context.Feeds.ToListAsync();

           

            return Ok(feed);
        }


        [HttpPost]
        [Route("[Action]")]
        public async Task<ActionResult<Feed>> AddFeed([FromBody] Feed feed)
        {
            var userId = decode();

            _context.Feeds.Add(new Feed
            {
                Title = feed.Title,
                FeedBody = feed.FeedBody,
                PostedBy = userId
            });
            await _context.SaveChangesAsync();
            return Ok(new { msg = "New Feed Added Successfully"});
        }


        [HttpPut]
        [Route("[Action]/{feedId}")]
        public string UpdateFeed(int feedId, [FromBody] Feed feed)
        {

            var userId = decode();

            try
            {
                var newChanges = _context.Feeds.Where(e => e.FeedId == feedId && e.PostedBy == userId).SingleOrDefault();
                if (newChanges == null)
                {
                    return "Update Failed";
                } 
                newChanges.Title = feed.Title;
                newChanges.FeedBody = feed.FeedBody;
                
               
                _context.SaveChanges();
                return "Update Successfull";
            }
            catch (Exception ex)
            {
                return "Error Occured " + ex;
            }
        }

        [HttpDelete]
        [Route("[Action]/{feedId}")]
        public string DeleteFeed(int? feedId)
        {

            var userId = decode();
            try
            {
                var feed = _context.Feeds.Where(e => e.FeedId == feedId && e.PostedBy == userId).SingleOrDefault();
                _context.Feeds.Remove(feed);
                _context.SaveChanges();
                return "Feed " + feed.FeedId + " is Deleted Successfully";
            }
            catch (Exception ex)
            {
                return "Exception occurred: " + ex;
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
