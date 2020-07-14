using System;

namespace TweetCake.DAL
{
    public class Notifications
    {
        public int Id { get; set; }
        public string NotificationName { get; set; }
        public User User { get; set; }
        public DateTime CreateNotification { get; set; }

    }
}