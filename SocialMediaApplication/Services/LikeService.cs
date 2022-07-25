
using SocialMediaApplication.Models;


namespace SocialMediaApplication.Services;

public class LikeService
{

    private readonly socialfeeddbContext _context;

    public LikeService()
    {

    }

    public LikeService(socialfeeddbContext context)
    {
        _context = context;
    }

    public virtual async Task<Object> Like(int feedId, int userId)
    {


        _context.Likes.Add(new Like
        {
            UserLiked = userId,
            FeedLiked = feedId
        })

     ;
        await _context.SaveChangesAsync();
        return new { msg = "User " + userId + " Liked Feed " + feedId + " Successfully" };
    }


    
    public virtual async Task<Object> Unlike(int feedId, int userId)
    {

        try
        {
            var feed = _context.Likes.Where(e => e.FeedLiked == feedId && e.UserLiked == userId).SingleOrDefault();
            _context.Likes.Remove(feed);
            _context.SaveChanges();
            return new { msg = "User " + userId + " Unliked Feed " + feedId + " Successfully" };
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    


}

