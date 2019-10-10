using System;
using System.Collections.Generic;

namespace ConestogaCarpoolApplication.Models
{
    public partial class RequestStatus
    {
        public RequestStatus()
        {
            Request = new HashSet<Request>();
        }

        public int RequestStatusId { get; set; }
        public string Status { get; set; }

        public ICollection<Request> Request { get; set; }
    }
}
