using Chatter.Application.Contracts.Repositories;
using Chatter.Application.Contracts.Services;
using Chatter.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task CreateAsync(Chat chat)
        {
            await _chatRepository.CreateAsync(chat);
        }

        public async Task DeleteAsync(int chatId)
        {
            await _chatRepository.DeleteAsync(chatId);
        }

        public IEnumerable<Chat> Get()
        {
            return _chatRepository.Get().ToList();
        }

        public IEnumerable<Chat> Get(int pageIndex, int pageSize)
        {
            return _chatRepository.Get()
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToList();
        }

        public async Task<Chat> GetAsync(int chatId)
        {
            return await _chatRepository.GetAsync(chatId);
        }

        public async Task UpdateAsync(Chat chat)
        {
            await _chatRepository.UpdateAsync(chat);
        }
    }
}
