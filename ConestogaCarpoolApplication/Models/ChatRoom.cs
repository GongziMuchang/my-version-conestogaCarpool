using System;
using System.Collections.Generic;

namespace ConestogaCarpoolApplication.Models
{
    public partial class ChatRoom
    {
        public ChatRoom()
        {
            Message = new HashSet<Message>();
        }

        public int ChatRoomId { get; set; }
        public int StatusId { get; set; }
        public int PassengerId { get; set; }
        public int DriverId { get; set; }

        public User Driver { get; set; }
        public User Passenger { get; set; }
        public ChatRoomStatus Status { get; set; }
        public ICollection<Message> Message { get; set; }
    }
}
