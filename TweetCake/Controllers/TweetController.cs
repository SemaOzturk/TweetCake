using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TweetCake.Application;
using TweetCake.Application.Services;
using TweetCake.DAL;
using TweetCake.Shared.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TweetCake.Controllers
{
    [Route("api/[controller]")]
    public class TweetController : Controller
    {
        private readonly ITweetService _tweetService;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public TweetController(ITweetService tweetService, IUserService userService, IMapper mapper)
        {
            _tweetService = tweetService;
            _userService = userService;
            _mapper = mapper;
        }


        [HttpGet("{id}")]
        public IActionResult GetTweets(int id)
        {
            return Ok(_tweetService.MainPageTweets(id)) ;
        }

        [HttpGet]
        public IActionResult Search(string text)
        {
          return Ok(_tweetService.Search(text));
        }
        [HttpPost]
        public IActionResult CreateTweet([FromBody] TweetCreateModel tweetCreate)
        {
            var tweet = _mapper.Map<Tweet>(tweetCreate);
            return Ok(_tweetService.Create(tweet));
        }
        //[HttpGet]
        //public IActionResult CreateTweet(Tweet tweet)
        //{
        //    tweet=new Tweet
        //    {
        //        CreateDate = DateTime.Now,
        //        LikeCount = 0,
        //      TweetText  = "ohh my @semaozturk my boss is #octopus",
        //      User = _userService.GetUserById(1),
        //      Retweet = null,
        //      IsDeleted = false
        //    };
        //    _tweetService.Create(tweet);
        //    return Ok();
        //}
    }
}
