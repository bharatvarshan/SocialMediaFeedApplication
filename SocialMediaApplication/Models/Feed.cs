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
        //[ForeignKey("Feed")]
        //public List<Likes>? LikedById { get; set; }
        //public List<Comments>? Comments { get; set; }
        //public List<TaggedUsers>? TaggedUsersId { get; set; }

        public static implicit operator List<object>(Feed v)
        {
            throw new NotImplementedException();
        }
    }


    

    

    
}
