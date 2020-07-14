using System;
using System.Collections.Generic;
using System.Text;

namespace TweetCake.Shared.Models
{
    public class UserLoginModel
    {
        //new User {Role = "admin", FirsName = "Sema", Password = "8523"}
        public string UserName { get; set; }
        public string Role { get; set; }
        public string Password { get; set; }

    }
}
