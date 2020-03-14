using Chatter.DAL.Infrastructure;
using Chatter.DAL.Infrastructure.Attributes;
using System;

namespace Chatter.DAL.StoredProcedures
{
    namespace Chats
    {
        [ProcedureName("SP_CreateChat")]
        internal class CreateChatSP : StoredProcedure
        {
            [InParameter] public string Name;
            [InParameter] public int ChatTypeId;
        }

        [ProcedureName("SP_DeleteChat")]
        internal class DeleteChatSP : StoredProcedure
        {
            [InParameter] public int Id;
        }

        [ProcedureName("SP_GetChats")]
        internal class GetChatsSP : StoredProcedure
        {
        }

        [ProcedureName("SP_GetChat")]
        internal class GetChatSP : StoredProcedure
        {
            [InParameter] public int Id;
        }

        [ProcedureName("SP_UpdateChat")]
        internal class UpdateChatSP : StoredProcedure
        {
            [InParameter] public int Id;
            [InParameter] public string Name;
            [InParameter] public int ChatTypeId;
        }
    }

    namespace Messages
    {
        [ProcedureName("SP_CreateMessage")]
        internal class CreateMessageSP : StoredProcedure
        {
            [InParameter] public string Text;
            [InParameter] public DateTime TimeStamp;
            [InParameter] public int ChatId;
            [InParameter] public int SenderId;
        }

        [ProcedureName("SP_GetMessage")]
        internal class GetMessageSP : StoredProcedure
        {
            [InParameter] public int Id;
        }

        [ProcedureName("SP_UpdateMessage")]
        internal class UpdateMessageSP : StoredProcedure
        {
            [InParameter] public int Id;
            [InParameter] public string Text;
            [InParameter] public DateTime TimeStamp;
            [InParameter] public int ChatId;
            [InParameter] public int SenderId;
        }

        [ProcedureName("SP_DeleteMessage")]
        internal class DeleteMessageSP : StoredProcedure
        {
            [InParameter] public int Id;
        }

        [ProcedureName("SP_GetMessagesByChatId")]
        internal class GetMessagesByChatIdSP : StoredProcedure
        {
            [InParameter] public int ChatId;
        }
    }

    namespace Tokens
    {
        [ProcedureName("SP_CreateToken")]
        internal class CreateTokenSP : StoredProcedure
        {
            [InParameter] public string Token;
            [InParameter] public DateTime Expires;
            [InParameter] public int UserId;
        }

        [ProcedureName("SP_DeleteToken")]
        public class DeleteTokenSP : StoredProcedure
        {
            [InParameter] public string Token;
        }

        [ProcedureName("SP_DeleteTokenByUserId")]
        public class DeleteTokenByUserIdSP : StoredProcedure
        {
            [InParameter] public int UserId;
        }
    }

    namespace Users
    {
        [ProcedureName("SP_CreateUser")]
        public class CreateUserSP : StoredProcedure
        {
            [InParameter] public string Nickname;
            [InParameter] public string Email;
            [InParameter] public string HashedPassword;
        }

        [ProcedureName("SP_GetUser")]
        public class GetUserSP : StoredProcedure
        {
            [InParameter] public int Id;
        }

        [ProcedureName("SP_GetUserByEmail")]
        public class GetUserByEmailSP : StoredProcedure
        {
            [InParameter] public string Email;
        }

        [ProcedureName("SP_GetUserByNickname")]
        public class GetUserByNicknameSP : StoredProcedure
        {
            [InParameter] public string Nickname;
        }

        [ProcedureName("SP_DeleteUser")]
        public class DeleteUserSP : StoredProcedure
        {
            [InParameter] public int Id;
        }

        [ProcedureName("SP_UpdateUser")]
        public class UpdateUserSP : StoredProcedure
        {
            [InParameter] public int Id;
            [InParameter] public string Nickname;
            [InParameter] public string Email;
            [InParameter] public string HashedPassword;
        }

        [ProcedureName("SP_GetUserByEmailAndNickname")]
        public class GetUserByEmailAndNicknameSP : StoredProcedure
        {
            [InParameter] public string Nickname;
            [InParameter] public string Email;
        }
    }

    namespace UserRoles
    {
        [ProcedureName("SP_CreateUserRole")]
        public class CreateUserRoleSP : StoredProcedure
        {
            [InParameter] public string Role;
        }

        [ProcedureName("SP_DeleteUserRole")]
        public class DeleteUserRoleSP : StoredProcedure
        {
            [InParameter] public int Id;
        }

        [ProcedureName("SP_GetUsersRoles")]
        public class GetUsersRolesSP : StoredProcedure
        {

        }

        [ProcedureName("SP_GetUserRole")]
        public class GetUserRoleSP : StoredProcedure
        {
            [InParameter] public int Id;
        }

        [ProcedureName("SP_UpdateUserRole")]
        public class UpdateUserRoleSP : StoredProcedure
        {
            [InParameter] public int Id;
            [InParameter] public string Role;
        }
    }

    namespace ChatTypes
    {
        [ProcedureName("SP_CreateChatType")]
        public class CreateChatTypeSP : StoredProcedure
        {
            [InParameter] public string Type;
        }

        [ProcedureName("SP_DeleteChatType")]
        public class DeleteChatTypeSP : StoredProcedure
        {
            [InParameter] public int Id;
        }

        [ProcedureName("SP_GetChatTypes")]
        public class GetChatTypesSP : StoredProcedure
        {

        }

        [ProcedureName("SP_GetChatType")]
        public class GetChatTypeSP : StoredProcedure
        {
            [InParameter] public int Id;
        }
    }

    namespace ChatUsers
    {
        [ProcedureName("SP_GetUsersByChatId")]
        public class GetUsersByChatIdSP : StoredProcedure
        {
            [InParameter] public int ChatId;
        }

        [ProcedureName("SP_GetUserChats")]
        public class GetUserChatsSP : StoredProcedure
        {
            [InParameter] public int UserId;
        }

        [ProcedureName("SP_GetChatUserRole")]
        public class GetChatUserRoleSP : StoredProcedure
        {
            [InParameter] public int ChatId;
            [InParameter] public int UserId;
        }

        [ProcedureName("SP_GetChatUser")]
        public class GetChatUserSP : StoredProcedure
        {
            [InParameter] public int Id;
        }

        [ProcedureName("SP_CreateChatUser")]
        public class CreateChatUserSP : StoredProcedure
        {
            [InParameter] public int ChatId;
            [InParameter] public int UserId;
            [InParameter] public int RoleId;
        }

        [ProcedureName("SP_UpdateChatUserRole")]
        public class UpdateChatUserRoleSP : StoredProcedure
        {
            [InParameter] public int ChatId;
            [InParameter] public int UserId;
            [InParameter] public int? RoleId;
        }

        [ProcedureName("SP_DeleteChatUser")]
        public class DeleteChatUserSP : StoredProcedure
        {
            [InParameter] public int Id;
        }
    }
}
