using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SocialMediaApplication.Models
{
    public class Likes
    {
        [Key]
        public int LikeId { get; set; }
        public int FeedId { get; set; }

        public int UserId { get; set; }

        
    }
}
