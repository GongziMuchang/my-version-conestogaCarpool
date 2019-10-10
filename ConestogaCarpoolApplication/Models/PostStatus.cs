using System;
using System.Collections.Generic;

namespace ConestogaCarpoolApplication.Models
{
    public partial class PostStatus
    {
        public PostStatus()
        {
            Post = new HashSet<Post>();
        }

        public int PostStatusId { get; set; }
        public string Status { get; set; }

        public ICollection<Post> Post { get; set; }
    }
}
