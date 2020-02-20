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
            if (chatRepository == null)
                throw new ArgumentNullException(nameof(chatRepository));

            _chatRepository = chatRepository;
        }

        public Task CreateAsync(Chat chat)
        {
            throw new System.NotImplementedException();
        }

        public Task DeleteAsync(int chatId)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Chat> Get(int pageIndex, int pageSize)
        {
            throw new System.NotImplementedException();
        }

        public Task<Chat> GetAsync(int chatId)
        {
            throw new System.NotImplementedException();
        }

        public Task UpdateAsync(Chat chat)
        {
            throw new System.NotImplementedException();
        }
    }
}
