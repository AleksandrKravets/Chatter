using Chatter.Application.Contracts.Repositories;
using Chatter.Application.Contracts.Services;
using Chatter.Application.DataTransferObjects.ChatTypes;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Chatter.Application.Services
{
    public class ChatTypeService : IChatTypeService
    {
        private readonly IChatTypeRepository _chatTypeRepository;

        public ChatTypeService(IChatTypeRepository chatTypeRepository)
        {
            _chatTypeRepository = chatTypeRepository ?? throw new ArgumentNullException(nameof(chatTypeRepository));
        }

        public Task<ICollection<ChatTypeModel>> GetAllAsync()
        {
            return _chatTypeRepository.GetAllAsync();
        }
    }
}
