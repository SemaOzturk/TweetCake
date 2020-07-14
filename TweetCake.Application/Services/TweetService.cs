using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using Microsoft.EntityFrameworkCore;
using TweetCake.DAL;

namespace TweetCake.Application
{
    public class TweetService : ITweetService
    {
        private IRepository<Tweet> _tweetRepository;
        private IRepository<Tag> _tagRepository;
        private IRepository<Mention> _mentionRepository;
        private IRepository<User> _userRepository;
        private IRepository<UserFriend> _userFriendRepository;

        public TweetService(IRepository<Tweet> tweetRepository, IRepository<Tag> tagRepository, IRepository<Mention> mentionRepository, IRepository<User> userRepository, IRepository<UserFriend> userFriendRepository)
        {
            _tweetRepository = tweetRepository;
            _tagRepository = tagRepository;
            _mentionRepository = mentionRepository;
            _userRepository = userRepository;
            _userFriendRepository = userFriendRepository;
        }

        public Tweet Create(Tweet entity)
        {
            var tweet = _tweetRepository.Insert(entity);
            _mentionRepository.AddRange(FindMentionsInTweet(tweet));
            _tagRepository.AddRange(FindTagsInTweet(tweet));

            return tweet;
        }

        public bool Delete(int id)
        {
            return _tweetRepository.Delete(id);
        }

        public IEnumerable<Mention> FindMentionsInTweet(Tweet tweet)
        {
           var tweetText = tweet.TweetText;
            tweetText += " ";
            for (int endIndex = 0; endIndex < tweetText.Length; endIndex++)
            {
                var startIndex = tweetText.IndexOf('@', endIndex);
                if (startIndex == -1)
                {
                    break;
                }
                endIndex = tweetText.IndexOf(' ', startIndex);
                var userName = tweetText.Substring(startIndex, endIndex - startIndex);
                 Mention mention = new Mention();
                mention.User= _userRepository.GetAll().FirstOrDefault(x => x.Username == userName);
                mention.MentionInTweet = tweet;
                yield return mention;
            }
        
        }

        public IEnumerable<Tag> FindTagsInTweet(Tweet tweet)
        {
           
            var tweetText = tweet.TweetText;
            tweetText += " ";
            for (int endIndex = 0; endIndex < tweetText.Length; endIndex++)
            {
                var startIndex = tweetText.IndexOf('#', endIndex);
                if (startIndex == -1)
                {
                    break;
                }
                endIndex = tweetText.IndexOf(' ', startIndex);
                Tag tag = new Tag();
                tag.TagInTweet = tweet;
                tag.TagText = tweetText.Substring(startIndex, endIndex - startIndex);
                tag.CreateTagDate = DateTime.Now;
                yield return tag ;
            }
        }

        public IEnumerable<Tweet> GetAllUserTweet(int userId)
        {
            return _tweetRepository.GetAll().Include(x=>x.User).Where(x => x.User.Id == userId);
        }
        /// <summary>
        /// User a ait tüm friendleri bulup userın ve tüm friendlerinin tweetlerini getirecek.
        /// </summary>
        /// <param name="userId">anasayfası gösterilecek user'a ait id</param>
        /// <returns></returns>
        public IEnumerable<Tweet> MainPageTweets(int userId)
        {
            var friends = _userRepository.GetById(userId).UserFriends.Where(x=>x.IsConfirm && x.IsDeleted).Select(x=>x.Friend);
            //IEnumerable<User> allFriends = _userFriendRepository.GetAll().Where(x => x.Friend.Id == userId && x.IsConfirm && x.IsDeleted==false).Select(x => x.Friend);
            var result = _tweetRepository.GetAll().Where(x=> friends.Any(y=> x.User.Id == y.Id));
            //var result = from friend in allFriends
            //             join tweet in _tweetRepository.GetAll() on friend.Id equals tweet.User.Id
            //             select tweet;

            
            return result.Where(x=>x.CreateDate>DateTime.Now.AddDays(-3)).OrderByDescending(x => x.CreateDate);

        }

        public IEnumerable<Tweet> Search(string text)
        {
            switch (text[0])
            {
                case '@':
                    return _tweetRepository.GetAll().Include(u=>u.User).Where(x => x.User.Username == text)
                        .OrderByDescending(x => x.CreateDate).Take(1);
                case '#':
                    return _tagRepository.GetAll().Where(x => x.TagText == text).Include(t=>t.TagInTweet).Select(x => x.TagInTweet)
                        .OrderByDescending(x => x.CreateDate).Take(10);
                default:
                    return _tweetRepository.GetAll().Where(x => x.TweetText.Contains(text))
                        .OrderByDescending(x => x.CreateDate).Take(10);
            }
        }

        public Tweet Update(Tweet tweet)
        {
            return _tweetRepository.Update(tweet);
        }

    }
}
