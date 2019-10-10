using System;
using System.Collections.Generic;

namespace ConestogaCarpoolApplication.Models
{
    public partial class LicenceClass
    {
        public LicenceClass()
        {
            User = new HashSet<User>();
        }

        public int LicenceClassId { get; set; }
        public string LicenceClass1 { get; set; }

        public ICollection<User> User { get; set; }
    }
}
