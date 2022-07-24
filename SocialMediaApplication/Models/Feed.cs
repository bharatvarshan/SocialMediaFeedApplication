using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SocialMediaApplication.Models
{
    
    public class Feed
    {
        [Key]
        [Required]
        public int FeedId { get; set; }
        [Required(ErrorMessage = "Provide Feed Title")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Provide Feed")]
        public string FeedBody { get; set; }
        public DateTime CreatedAt { get; set; }
        public List<Likes>? LikedById { get; set; }
        public List<Comments>? Comments { get; set; }
        public List<TaggedUsers>? TaggedUsersId { get; set; }
    }


    public class Likes
    {
        [ForeignKey("Users")]
        public int Id { get; set; }
    }

    public class Comments
    {
        [ForeignKey("Users")]
        public int Id { get; set; }
        public int Comment { get; set; }
    }

    public class TaggedUsers
    {
        [ForeignKey("Users")]
        public int Id { get; set; }
    }
}
