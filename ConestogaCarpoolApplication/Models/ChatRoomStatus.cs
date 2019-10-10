using System;
using System.Collections.Generic;

namespace ConestogaCarpoolApplication.Models
{
    public partial class ChatRoomStatus
    {
        public ChatRoomStatus()
        {
            ChatRoom = new HashSet<ChatRoom>();
        }

        public int ChatRoomStatusId { get; set; }
        public string Status { get; set; }

        public ICollection<ChatRoom> ChatRoom { get; set; }
    }
}
