using System;
using System.Collections.Generic;
using System.Text;
using TweetCake.DAL;

namespace TweetCake.Application.Services.IServices
{
    public interface IUserFriendService 
    {
        UserFriend Create(UserFriend user);
        UserFriend Update(UserFriend user);
        bool Delete(int id);
        IEnumerable<UserFriend> GetAllUserFriends();
        UserFriend GetUserById(int id);
      

    }
}
