using System;
using System.Collections.Generic;

namespace ConestogaCarpoolApplication.Models
{
    public partial class Ride
    {
        public Ride()
        {
            Review = new HashSet<Review>();
        }

        public int RideId { get; set; }
        public int StatusId { get; set; }
        public int PostId { get; set; }
        public int RequestId { get; set; }

        public Post Post { get; set; }
        public Request Request { get; set; }
        public RideStatus Status { get; set; }
        public ICollection<Review> Review { get; set; }
    }
}
