using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace TweetCake.DAL
{
    public class Tweet : IBaseEntity
    {
        public string TweetText { get; set; }
        public DateTime Time { get; set; } //datetime çünkü saniye olarak tutulduğunda db de süreyi sürekli artırmam gerekiyor.lazım olan twetin atıldığı tarih(db için)
        public int UserId { get; set; }
        public int LikeCount { get; set; }
        public int RetweetCount { get; set; }
        [ForeignKey(nameof(UserId))]
        public User User { get; set; }
        public Tweet Retweet { get; set; }//bir user başka bir userın twettini retweetlediğinde
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
