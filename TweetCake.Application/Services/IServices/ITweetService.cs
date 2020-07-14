using System;
using System.Collections.Generic;
using System.Text;
using TweetCake.DAL;
using TweetCake.Shared.Models;

namespace TweetCake.Application
{
    /*
     "oh my @sema #help my boss is an #octupus";

        1tweti kaydet
        2ayıkla
        {
        "mention":"mention tablosuna kaydet"
        "tag":"tagler tag tablosuna kaydet"
        }
        3-like sayısını artıracak update edecek
        retweet için de aynı ama yeni bit tweet kaydı oluşacak bunun tweet id olmayacak
        retweet atılan twetin id si ilk twete yazılacak



         */
    public interface ITweetService
    {
        IEnumerable<Tag> FindTagsInTweet(Tweet tweet);
        IEnumerable<Mention> FindMentionsInTweet(Tweet tweet);
        Tweet Create(Tweet tweet);
        Tweet Update(Tweet tweet);
        bool Delete(int id);
        IEnumerable<Tweet> GetAllUserTweet(int userId);
        IEnumerable<Tweet> MainPageTweets(int userId);
        public IEnumerable<Tweet> Search(string text);
    }

}
