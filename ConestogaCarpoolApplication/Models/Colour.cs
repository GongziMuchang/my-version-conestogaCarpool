using System;
using System.Collections.Generic;

namespace ConestogaCarpoolApplication.Models
{
    public partial class Colour
    {
        public Colour()
        {
            Vehicle = new HashSet<Vehicle>();
        }

        public int ColourId { get; set; }
        public string Colour1 { get; set; }

        public ICollection<Vehicle> Vehicle { get; set; }
    }
}
