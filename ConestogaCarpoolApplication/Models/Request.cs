using System;
using System.Collections.Generic;

namespace ConestogaCarpoolApplication.Models
{
    public partial class Request
    {
        public Request()
        {
            Ride = new HashSet<Ride>();
        }

        public int RequestId { get; set; }
        public int StatusId { get; set; }
        public int PassengerId { get; set; }
        public int PostId { get; set; }

        public User Passenger { get; set; }
        public Post Post { get; set; }
        public RequestStatus Status { get; set; }
        public ICollection<Ride> Ride { get; set; }
    }
}
