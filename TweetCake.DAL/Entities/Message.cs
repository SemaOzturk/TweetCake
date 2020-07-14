using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TweetCake.DAL.Entities
{
    public class Message:IBaseEntity
    {
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }
        public bool IsDeleted { get; set; }
        public string MessageText { get; set; }
        [ForeignKey(nameof(ReceivedUserId))]
        public User SenderUser { get; set; }
        [ForeignKey(nameof(SenderUserId))]
        public User ReceivedUser { get; set; }
        public int SenderUserId { get; set; }
        public int ReceivedUserId { get; set; }
    }
}
