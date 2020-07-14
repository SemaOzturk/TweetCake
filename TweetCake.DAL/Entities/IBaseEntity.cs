using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TweetCake.DAL
{


    public interface IBaseEntity
    {
        [Key]
        int Id { get; set; }
        DateTime CreateDate { get; set; }
        bool IsDeleted { get; set; }
    }
}
