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
            _messageRepository =
                messageRepository ?? throw new ArgumentNullException(nameof(messageRepository));
        }

        public Task CreateAsync(Message message)
        {
            // Проверять на наличие чата в базе перед созданием
            return _messageRepository.CreateAsync(message);
        }

        public Task DeleteAsync(int messageId)
        {
            return _messageRepository.DeleteAsync(messageId);
        }

        public Task<Message> GetAsync(int messageId)
        {
            return _messageRepository.GetAsync(messageId);
        }

        public Task UpdateAsync(Message message)
        {
            return _messageRepository.UpdateAsync(message);
        }

        public Task<IEnumerable<Message>> GetAsync(int chatId, int pageIndex, int pageSize)
        {
            return null;
        }

        public Task<IEnumerable<Message>> GetAllAsync(int chatId)
        {
            return _messageRepository.GetAllAsync(chatId);
        }
    }
}
