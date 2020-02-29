using Chatter.Application.Contracts.Repositories;
using Chatter.Application.Contracts.Services;
using Chatter.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Chatter.Application.Services
{
    public class ChatService : IChatService
    {
        private readonly IChatRepository _chatRepository;

        public ChatService(IChatRepository chatRepository)
        {
            _chatRepository = 
                chatRepository ?? throw new ArgumentNullException(nameof(chatRepository));
        }

        public Task CreateAsync(Chat chat)
        {
            return  _chatRepository.CreateAsync(chat);
        }

        public Task DeleteAsync(int chatId)
        {
            return _chatRepository.DeleteAsync(chatId);
        }

        public Task<IEnumerable<Chat>> GetAsync()
        {
            return _chatRepository.GetAllAsync();
        }

        public Task<IEnumerable<Chat>> GetAsync(int pageIndex, int pageSize)
        {
            return null;
        }

        public Task<Chat> GetAsync(int chatId)
        {
            return _chatRepository.GetAsync(chatId);
        }

        public Task UpdateAsync(Chat chat)
        {
            return _chatRepository.UpdateAsync(chat);
        }
    }
}
