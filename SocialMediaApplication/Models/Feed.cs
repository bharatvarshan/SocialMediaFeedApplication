using System.ComponentModel.DataAnnotations;

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
        public string LikedBy { get; set; }
        public string Comments { get; set; }
        public string TaggedUsers { get; set; }


    }
}
