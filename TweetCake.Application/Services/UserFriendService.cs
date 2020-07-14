using System;
using System.Collections.Generic;
using System.Text;
using TweetCake.Application.Services.IServices;
using TweetCake.DAL;

namespace TweetCake.Application.Services
{
    public  class UserFriendService : IUserFriendService
    {
        private readonly IRepository<UserFriend> _userFriendsRepository;
        public UserFriendService(IRepository<UserFriend> userFriendsRepository)
        {
            _userFriendsRepository = userFriendsRepository;
        }


        public UserFriend Create(UserFriend user)
        {
            return _userFriendsRepository.Insert(user);
        }

        public UserFriend Update(UserFriend user)
        {
            return _userFriendsRepository.Update(user);
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserFriend> GetAllUserFriends()
        {
            throw new NotImplementedException();
        }

        public UserFriend GetUserById(int id)
        {
            throw new NotImplementedException();
        }

   
    }
}
