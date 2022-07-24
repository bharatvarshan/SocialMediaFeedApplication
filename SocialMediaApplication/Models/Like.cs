using System;
using System.Collections.Generic;

namespace SocialMediaApplication.Models
{
    public partial class Like
    {
        public int LikeId { get; set; }
        public int? UserLiked { get; set; }
        public int? FeedLiked { get; set; }

        public virtual Feed? FeedLikedNavigation { get; set; }
        public virtual User? UserLikedNavigation { get; set; }
    }
}
