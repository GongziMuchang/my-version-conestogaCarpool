using System;
using System.Collections.Generic;

namespace ConestogaCarpoolApplication.Models
{
    public partial class Vehicle
    {
        public int VehicleId { get; set; }
        public int UserId { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public int ColourId { get; set; }
        public string Plate { get; set; }
        public byte[] Image { get; set; }

        public Colour Colour { get; set; }
        public User User { get; set; }
    }
}
