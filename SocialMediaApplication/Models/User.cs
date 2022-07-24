using System;
using System.Collections.Generic;

namespace SocialMediaApplication.Models
{
    public partial class User
    {
        public User()
        {
            Comments = new HashSet<Comment>();
            Feeds = new HashSet<Feed>();
            Likes = new HashSet<Like>();
            Tags = new HashSet<Tag>();
        }

        public int UserId { get; set; }
        public string UserName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public bool IsAdmin { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Feed> Feeds { get; set; }
        public virtual ICollection<Like> Likes { get; set; }
        public virtual ICollection<Tag> Tags { get; set; }
    }
}
