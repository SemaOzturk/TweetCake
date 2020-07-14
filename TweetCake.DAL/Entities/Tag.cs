using System;

namespace TweetCake.DAL
{
    public class Tag : IBaseEntity
    {
        public Tweet TagInTweet { get; set; }
        public string TagText { get; set; }
        public DateTime CreateTagDate { get; set; }
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
