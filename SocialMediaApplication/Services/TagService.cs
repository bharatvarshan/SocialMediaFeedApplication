using SocialMediaApplication.Models;

namespace SocialMediaApplication.Services
{
    public class TagService
    {
        private readonly socialfeeddbContext _context;

        public TagService()
        {

        }

        public TagService(socialfeeddbContext context)
        {
            _context = context;
        }

        public virtual async Task<Object> Tag(int userId, int feedId)
        {



            _context.Tags.Add(new Tag
            {
                FeedTagged = feedId,
                UserTagged = userId
            })

         ;
            await _context.SaveChangesAsync();
            return new { msg = "User " + userId +" Tagged " + feedId +" Successfully" };
        }
    }
}
