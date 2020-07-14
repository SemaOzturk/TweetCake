using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using TweetCake.DAL;
using TweetCake.DAL.Entities;
using TweetCake.Queries;

namespace TweetCake.Handlers
{
    public class SaveMessageHandler:IRequestHandler<SaveMessageQuery>
    {
        private readonly IRepository<Message> _messageRepository;

        public SaveMessageHandler(IRepository<Message> messageRepository)
        {
            _messageRepository = messageRepository;
        }

        public Task<Unit> Handle(SaveMessageQuery request, CancellationToken cancellationToken)
        {
            var message = new Message();
            message.MessageText = request.SendMessageObject.MessageText;
            message.ReceivedUser.Username = request.SendMessageObject.ReceivedUserName;
            message.SenderUser.Username = request.SendMessageObject.SenderUserName;
            _messageRepository.Insert(message);
            return Task.FromResult(Unit.Value);
        }
    }
}
