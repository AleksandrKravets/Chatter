using Chatter.Application.Contracts.Repositories;
using Chatter.Application.Contracts.Services;
using Chatter.Application.DataTransferObjects.Chats;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Chatter.Application.Services
{
    public class ChatService : IChatService
    {
        private readonly IChatRepository _chatRepository;
        private readonly IChatUserRepository _chatUserRepository;

        public ChatService(IChatRepository chatRepository, IChatUserRepository chatUserRepository)
        {
            _chatUserRepository = chatUserRepository;
            _chatRepository = chatRepository;
        }

        public Task CreateAsync(CreateChatModel model)
        {
            // Check if chat with such name exist
            // Check if user exist
            // Create chat
            // Create ChatUser(userRole - Chat admin)

            return _chatRepository.CreateAsync(model);
        }

        public Task DeleteAsync(long chatId)
        {
            return _chatRepository.DeleteAsync(chatId);
        }

        public Task<ICollection<ChatModel>> GetAsync()
        {
            return _chatRepository.GetAsync();
        }

        public Task<ChatModel> GetAsync(long chatId)
        {
            return _chatRepository.GetAsync(chatId);
        }

        public Task JoinChatAsync(long chatId, long userId)
        {
            // Check if chat with such id exist
            // Check if user exist
            // Check if user with such id doesnt ieist in this chat
            // Create ChatUser
            return _chatUserRepository.CreateAsync(userId, chatId, 1);
        }

        public Task LeaveChatAsync(long chatId, long userId)
        {
            // Check if chat with such id exist
            // Check if user exist
            // Delete chatUser by chatId and userId
            return _chatUserRepository.DeleteAsync(userId, chatId);
        }

        public Task UpdateAsync(long id, UpdateChatModel model)
        {
            return _chatRepository.UpdateAsync(id, model);
        }
    }
}
