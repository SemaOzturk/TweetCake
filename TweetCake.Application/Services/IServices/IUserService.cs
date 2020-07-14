using System;
using System.Collections.Generic;
using System.Text;
using TweetCake.DAL;

namespace TweetCake.Application.Services
{
    public interface IUserService
    {
        User Create(User user);
        User Update(User user);
        bool Delete(int id);
        IEnumerable<User> GetAllUser();
        User GetUserById(int id); 
      //  bool AddToFriend(int friendUserId, int userId);
    }
}
