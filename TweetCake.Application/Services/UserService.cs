using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using TweetCake.DAL;

namespace TweetCake.Application.Services
{
    public  class UserService : IUserService
    {
        private readonly IRepository<User> _userRepository;
        private readonly IRepository<UserFriend> _userFriendRepository;

      
        public UserService(IRepository<User> userRepository, IRepository<UserFriend> userFriendRepository)
        {
            _userRepository = userRepository;
            _userFriendRepository = userFriendRepository;
        }
        public User Create(User user)
        {
            return _userRepository.Insert(user);
        }

        public User Update(User user)
        {
            return _userRepository.Update(user);
        }

        public bool Delete(int id)
        {
            return _userRepository.Delete(id);
        }

        public User GetUserById(int id)
        {
            return _userRepository.GetById(id);
        }

        public IEnumerable<User> GetAllUser()
        {
            return _userRepository.GetAll();
        }
        //public bool AddToFriend(int friendUserId,int userId)
        //{

        //  _userRepository.GetAll().Include(x=>x.UserFriends).
        //}
    }
}
