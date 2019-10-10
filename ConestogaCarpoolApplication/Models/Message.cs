using System;
using System.Collections.Generic;

namespace ConestogaCarpoolApplication.Models
{
    public partial class Message
    {
        public int MessageId { get; set; }
        public string Message1 { get; set; }
        public int ChatRoomId { get; set; }
        public int UserId { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Time { get; set; }

        public ChatRoom ChatRoom { get; set; }
        public User User { get; set; }
    }
}
