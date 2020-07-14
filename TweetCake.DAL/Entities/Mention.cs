using System;

namespace TweetCake.DAL
{
    public class Mention : IBaseEntity
    {
        public User User { get; set; }
        public Tweet MentionInTweet { get; set; }
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
