using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using TweetCake.Application.Hubs;

namespace TweetCake.Queries
{
    public class SaveMessageQuery : IRequest
    {
        public SendMessageObject SendMessageObject { get; set; }

    }
}
