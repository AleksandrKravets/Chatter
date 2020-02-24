using Chatter.Application.Contracts.Repositories;
using Chatter.Application.Contracts.Services;
using Chatter.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace Chatter.Application.Services
{
    public class MessageService : IMessageService
    {
        private readonly IMessageRepository _messageRepository;

        public MessageService(IMessageRepository messageRepository)
        {
            _messageRepository =
                messageRepository ?? throw new ArgumentNullException(nameof(messageRepository));
        }

        public async Task CreateAsync(Message message)
        {
            await _messageRepository.CreateAsync(message);
        }

        public async Task DeleteAsync(int messageId)
        {
            await _messageRepository.DeleteAsync(messageId);
        }

        public async Task<Message> GetAsync(int messageId)
        {
            return await _messageRepository.GetAsync(messageId);
        }

        public async Task UpdateAsync(Message message)
        {
            await _messageRepository.UpdateAsync(message);
        }

        public IEnumerable<Message> Get(int chatId, int pageIndex, int pageSize)
        {
            return _messageRepository.Get(chatId)
                .Where(message => message.ChatId == chatId)
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToList();
        }

        public IEnumerable<Message> Get(int chatId)
        {
            return _messageRepository.Get(chatId).ToList();
        }
    }
}
