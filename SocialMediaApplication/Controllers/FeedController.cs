using SocialMediaApplication.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SocialMediaApplication.DbContexts;

namespace SocialMediaApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedController : ControllerBase
    {
        private readonly SocialMediaDbContext _context;
        public FeedController(SocialMediaDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        [Route("[Action]")]
        public async Task<ActionResult<List<Feed>>> Index()
        {
            return Ok(_context.Feeds.ToList<Feed>());
        }

        [HttpGet]
        [Route("[Action]/{id}")]
        public async Task<ActionResult<Object>> GetFeed(int id)
        {
            if (id == null || _context?.Feeds == null)
            {
                return BadRequest(new { msg = "Id should not be null" });
            }

            var feed = await _context.Feeds.FirstOrDefaultAsync(x => x.FeedId == id);

            if (feed == null)
            {
                return NotFound(new { msg = $"Feed not found with id {id}" });
            }

            return Ok(feed);
        }


        [HttpPut]
        [Route("[Action]/{userId}")]
        public async Task<ActionResult<User>> AddFeed(int userId, [FromBody] Feed feed)
        {

            Console.WriteLine(feed.FeedId);
            if (true)
            {
                var user = await _context.Users.FirstOrDefaultAsync(x => x.UserId == userId);
                if (user != null && feed != null)
                {
                        //var likesl = new List<Likes>();
                        //Likes l = new Likes()
                        //{
                        //    Id = 1
                        //};
                        //likesl.Append(l);
                        //var commentl = new List<Comments>();
                        //Comments c = new Comments()
                        //{
                    
                        //    Id = 1,
                        //    Comment = "abc"
                        //};
                        //commentl.Append(c);

                        //var tags = new List<TaggedUsers>();
                        //TaggedUsers t = new TaggedUsers()
                        //{
                        //    Id = 1
                        //};
                        //tags.Append(t);
                        //Feed feedq = new Feed()
                        //{
                        //    FeedId = 1,
                        //    Title = "title",
                        //    FeedBody = "bodydfsdf",
                        //    CreatedAt = DateTime.Now,
                        //    LikedById = likesl,
                        //    Comments = commentl,
                        //    TaggedUsersId = tags
                       
                        //};
                    user.Posts?.Append(feed);
                    await _context.SaveChangesAsync();
                    return Ok(user);

                }
                return Ok("Error while Adding feed");

            }
        }


        //[HttpPut]
        //[Route("[Action]/{studentid}")]
        //public async Task<ActionResult<User>> UpdateStudentProfile(int studentid, [FromBody] User user)
        //{
        //    if (true)
        //    {
        //        var userdb = await _context.Users.FirstOrDefaultAsync(x => x.Id == studentid);
        //        if (userdb != null)
        //        {

        //            userdb.Name = user.Name;

        //            userdb.Email = user.Email;
        //            userdb.Password = user.Password;
        //            await _context.SaveChangesAsync();
        //            return Ok(userdb);

        //        }
        //        return Ok("Error while updating Student Profile data");

        //    }

        //}
    }
}
