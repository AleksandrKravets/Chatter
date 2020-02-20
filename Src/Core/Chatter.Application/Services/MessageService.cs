using Chatter.Application.Contracts.Repositories;
using Chatter.Application.Contracts.Services;
using Chatter.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Chatter.Application.Services
{
    public class MessageService : IMessageService
    {
        private readonly IMessageRepository _messageRepository;

        public MessageService(IMessageRepository messageRepository)
        {
            if (messageRepository == null)
                throw new ArgumentNullException(nameof(messageRepository));

            _messageRepository = messageRepository;
        }

        public Task CreateAsync(Message message)
        {
            throw new System.NotImplementedException();
        }

        public Task DeleteAsync(int messageId)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Message> Get(int chatId, int pageIndex, int pageSize)
        {
            throw new System.NotImplementedException();
        }

        public Task<Message> GetAsync(int messageId)
        {
            throw new System.NotImplementedException();
        }

        public Task UpdateAsync(Message message)
        {
            throw new System.NotImplementedException();
        }
    }
}
