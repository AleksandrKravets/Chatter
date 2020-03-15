using Chatter.Application.Contracts.Repositories;
using Chatter.Application.Contracts.Services;
using Chatter.Application.Infrastructure;
using Chatter.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace Chatter.Application.Services
{
    public class ChatService : IChatService
    {
        private readonly IChatRepository _chatRepository;
        private readonly IChatUserRepository _chatUserRepository;
        private readonly IUserRepository _userRepository;
        //private readonly IUserRoleRepository _userRoleRepository;

        public ChatService(IChatRepository chatRepository, IChatUserRepository chatUserRepository, 
            IUserRepository userRepository/*, IUserRoleRepository userRoleRepository*/)
        {
            //_userRoleRepository =
                //userRoleRepository ?? throw new ArgumentNullException(nameof(userRoleRepository));
            _userRepository = 
                userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            _chatUserRepository =
                chatUserRepository ?? throw new ArgumentNullException(nameof(chatUserRepository));
            _chatRepository = 
                chatRepository ?? throw new ArgumentNullException(nameof(chatRepository));
        }

        public async Task<IResponse> CreateAsync(Chat chat)
        {
            if (!await CheckIfChatExists(chat.Name))
            {
                var user = await _userRepository.GetAsync(chat.CreatorId);

                if (user != null)
                {
                    var result = await _chatRepository.CreateAsync(chat);

                    var createdChat = await _chatRepository.GetChatByNameAsync(chat.Name);

                    await _chatUserRepository.CreateAsync(new ChatUser
                    {
                        UserId = user.Id,
                        ChatId = createdChat.Id,
                        Role = UserRole.Admin
                    });

                    return new BaseResponse
                    {
                        Status = result > 0 ? ResponseStatus.Success : ResponseStatus.Failure
                    };
                }
            }

            return new BaseResponse
            {
                Status = ResponseStatus.Failure
            };
        }

        public async Task<IResponse> DeleteAsync(int chatId)
        {
            var result = await _chatRepository.DeleteAsync(chatId);

            return new BaseResponse 
            {
                Status = result > 0 ? ResponseStatus.Success : ResponseStatus.Failure
            };
        }

        public async Task<IResponse> GetAsync()
        {
            var chats = await _chatRepository.GetAllAsync();

            return new ResponseObject
            {
                Result = chats,
                Status = ResponseStatus.Success
            };
        }

        public async Task<IResponse> GetAsync(int pageIndex, int pageSize)
        {
            if (pageIndex < 0)
                return new BaseResponse { Status = ResponseStatus.Failure };

            var chats = await _chatRepository.GetChatsAsync(pageIndex * pageSize, pageSize);

            return new ResponseObject
            {
                Result = chats, 
                Status = ResponseStatus.Success
            };
        }

        public async Task<IResponse> GetAsync(int chatId)
        {
            var chat = await _chatRepository.GetAsync(chatId);

            if(chat == null)
                return new BaseResponse
                {
                    Status = ResponseStatus.Failure
                };

            return new ResponseObject 
            { 
                Result = chat, 
                Status = ResponseStatus.Success 
            };
        }

        public async Task<IResponse> JoinChatAsync(int chatId, int userId)
        {
            var chat = await _chatRepository.GetAsync(chatId);

            if(chat != null)
            {
                var user = await _userRepository.GetAsync(userId);

                if(user != null)
                {
                    /*if(roleId != null)
                    {
                        var role = await _userRoleRepository.GetAsync(roleId.Value);

                        if(role != null)
                        {
                            var rowsAffected = await _chatUserRepository.CreateAsync(new ChatUser 
                            { 
                                ChatId = chatId, 
                                UserId = userId, 
                                RoleId = roleId.Value 
                            });

                            return new BaseResponse { Status = rowsAffected > 0 ? ResponseStatus.Success : ResponseStatus.Failure };
                        }
                    }*/

                    var chatUser = await _chatUserRepository.GetChatUserByKeysAsync(chatId, userId);

                    if(chatUser == null)
                    {
                        var rowsAffected = await _chatUserRepository.CreateAsync(new ChatUser
                        {
                            ChatId = chatId,
                            UserId = userId,
                            Role = UserRole.Member
                        });

                        return new BaseResponse { Status = rowsAffected > 0 ? ResponseStatus.Success : ResponseStatus.Failure };
                    }
                }
            }

            return new BaseResponse { Status = ResponseStatus.Failure };
        }

        public async Task<IResponse> LeaveChatAsync(int chatId, int userId)
        {
            var chat = await _chatRepository.GetAsync(chatId);

            if (chat != null)
            {
                var user = await _userRepository.GetAsync(userId);

                if (user != null)
                {
                    var rowsAffected = await _chatUserRepository.DeleteChatUserByChatIdAndUserIdAsync(chatId, userId);
                    
                    return new BaseResponse 
                    { 
                        Status = rowsAffected > 0 ? ResponseStatus.Success : ResponseStatus.Failure 
                    };
                }
            }

            return new BaseResponse { Status = ResponseStatus.Failure };
        }

        public async Task<IResponse> UpdateAsync(Chat chat)
        {
            var result = await _chatRepository.UpdateAsync(chat);

            return new BaseResponse
            {
                Status = result > 0 ? ResponseStatus.Success : ResponseStatus.Failure
            };
        }

        private async Task<bool> CheckIfChatExists(string chatName)
        {
            var chat = await _chatRepository.GetChatByNameAsync(chatName);
            return !(chat == null);
        }
    }
}
