using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.SignalR;
using TweetCake.DAL;
using TweetCake.DAL.Entities;
using TweetCake.Queries;

namespace TweetCake.Application.Hubs
{
    public class ChatHub:Hub
    {
        public ChatHub(IMediator mediator)
        {
            _mediator = mediator;
        }

        private readonly IMediator _mediator;

        public Task SendMessage(SendMessageObject sendMessage)
        {
            var saveMessageQuery = new SaveMessageQuery();
            saveMessageQuery.SendMessageObject = sendMessage;
            _mediator.Send(saveMessageQuery);
            return Clients.All.SendAsync("ReceiveMessage", sendMessage);
        }

        public void SaveToMessages(SendMessageObject sendMessage)
        {

        }
    }

    public class SendMessageObject
    {
        public string SenderUserName { get; set; }
        public string ReceivedUserName { get; set; }
        public string MessageText { get; set; }

    } 
}
