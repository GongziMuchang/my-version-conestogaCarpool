using System;
using System.Collections.Generic;

namespace ConestogaCarpoolApplication.Models
{
    public partial class User
    {
        public User()
        {
            ChatRoomDriver = new HashSet<ChatRoom>();
            ChatRoomPassenger = new HashSet<ChatRoom>();
            Message = new HashSet<Message>();
            Post = new HashSet<Post>();
            Request = new HashSet<Request>();
            ReviewDriver = new HashSet<Review>();
            ReviewPassenger = new HashSet<Review>();
            Vehicle = new HashSet<Vehicle>();
        }

        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public byte[] Image { get; set; }
        public int? LicenceClassId { get; set; }
        public int? Experience { get; set; }

        public LicenceClass LicenceClass { get; set; }
        public ICollection<ChatRoom> ChatRoomDriver { get; set; }
        public ICollection<ChatRoom> ChatRoomPassenger { get; set; }
        public ICollection<Message> Message { get; set; }
        public ICollection<Post> Post { get; set; }
        public ICollection<Request> Request { get; set; }
        public ICollection<Review> ReviewDriver { get; set; }
        public ICollection<Review> ReviewPassenger { get; set; }
        public ICollection<Vehicle> Vehicle { get; set; }
    }
}
