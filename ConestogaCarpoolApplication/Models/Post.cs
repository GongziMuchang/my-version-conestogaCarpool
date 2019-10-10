using System;
using System.Collections.Generic;

namespace ConestogaCarpoolApplication.Models
{
    public partial class Post
    {
        public Post()
        {
            Request = new HashSet<Request>();
            Ride = new HashSet<Ride>();
        }

        public int PostId { get; set; }
        public int StatusId { get; set; }
        public int DriverId { get; set; }
        public string Destination { get; set; }
        public string Location { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Time { get; set; }

        public User Driver { get; set; }
        public PostStatus Status { get; set; }
        public ICollection<Request> Request { get; set; }
        public ICollection<Ride> Ride { get; set; }
    }
}
