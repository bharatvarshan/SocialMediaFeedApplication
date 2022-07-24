using System;
using System.Collections.Generic;

namespace SocialMediaApplication.Models
{
    public partial class Comment
    {
        public int CommentId { get; set; }
        public int? CommentedBy { get; set; }
        public int? CommentedFeed { get; set; }
        public string? Comment1 { get; set; }

        public virtual User? CommentedByNavigation { get; set; }
        public virtual Feed? CommentedFeedNavigation { get; set; }
    }
}
