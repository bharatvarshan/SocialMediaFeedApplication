using System;
using System.Collections.Generic;

namespace SocialMediaApplication.Models
{
    public partial class Tag
    {
        public int TagId { get; set; }
        public int? FeedTagged { get; set; }
        public int? UserTagged { get; set; }

        public virtual Feed? FeedTaggedNavigation { get; set; }
        public virtual User? UserTaggedNavigation { get; set; }
    }
}
