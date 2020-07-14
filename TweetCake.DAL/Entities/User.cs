using System;
using System.Collections.Generic;

namespace TweetCake.DAL
{
    public class User : IBaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string FirsName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public ICollection<UserFriend> UserFriends { get; set; }
        public ICollection<Tweet> Tweets { get; set; }
        public DateTime CreateDate { get; set; }
        public bool IsDeleted { get; set; } 
    }

    public class  NotificationType
    {
        public int Id { get; set; }
      


    }
}
