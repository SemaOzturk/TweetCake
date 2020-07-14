using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace TweetCake.DAL
{
    public class UserFriend : IBaseEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public User User { get; set; }
        public int FriendId { get; set; }
        [ForeignKey(nameof(FriendId))]
        public User Friend { get; set; }
        public bool IsBlocked { get; set; }
        public DateTime CreateDate { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsConfirm { get; set; }
    }
}
