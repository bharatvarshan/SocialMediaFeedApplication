using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SocialMediaApplication.Models
{
    public class TaggedUsers
    {
        [Key]
        public int CommentId { get; set; }
        public int FeedId { get; set; }

        public int UserId { get; set; }
       
    }
}
