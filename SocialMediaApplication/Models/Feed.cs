using System;
using System.Collections.Generic;

namespace SocialMediaApplication.Models
{
    public partial class Feed
    {
        public Feed()
        {
            Comments = new HashSet<Comment>();
            Likes = new HashSet<Like>();
            Tags = new HashSet<Tag>();
        }

        public int FeedId { get; set; }
        public string Title { get; set; } = null!;
        public string FeedBody { get; set; } = null!;
        public int? PostedBy { get; set; }

        public virtual User? PostedByNavigation { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Like> Likes { get; set; }
        public virtual ICollection<Tag> Tags { get; set; }
    }
}
