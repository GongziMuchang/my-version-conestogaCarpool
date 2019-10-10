using System;
using System.Collections.Generic;

namespace ConestogaCarpoolApplication.Models
{
    public partial class Review
    {
        public int ReviewId { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
        public int RideId { get; set; }
        public int PassengerId { get; set; }
        public int DriverId { get; set; }

        public User Driver { get; set; }
        public User Passenger { get; set; }
        public Ride Ride { get; set; }
    }
}
