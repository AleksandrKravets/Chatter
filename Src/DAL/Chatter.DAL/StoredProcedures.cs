using Quantum.DAL.Infrastructure;
using Quantum.DAL.Infrastructure.Attributes;
using System;

namespace Chatter.DAL.StoredProcedures
{
    namespace Chats
    {
        [ProcedureName("CreateChat")]
        internal class SPCreateChat : StoredProcedure
        {
            [InParameter] public string Name;
            [InParameter] public long CreatorId;
            [InParameter] public long ChatTypeId;
        }

        [ProcedureName("DeleteChat")]
        internal class SPDeleteChat : StoredProcedure
        {
            [InParameter] public long Id;
        }

        [ProcedureName("GetChat")]
        internal class SPGetChatById : StoredProcedure
        {
            [InParameter] public long Id;
        }

        [ProcedureName("GetChats")]
        internal class SPGetChats : StoredProcedure
        {
        }

        [ProcedureName("UpdateChat")]
        internal class SPUpdateChat : StoredProcedure
        {
            [InParameter] public long Id;
            [InParameter] public string Name;
            [InParameter] public int ChatTypeId;
        }

        [ProcedureName("GetChatByName")]
        internal class SPGetChatByName : StoredProcedure
        {
            [InParameter] public string Name;
        }
    }

    namespace ChatsUsers
    {
        [ProcedureName("DeleteChatUserById")]
        internal class SPDeleteChatUserById : StoredProcedure
        {
            [InParameter] public long Id;
        }

        [ProcedureName("CreateChatUser")]
        internal class SPCreateChatUser : StoredProcedure
        {
            [InParameter] public long UserId;
            [InParameter] public long ChatId;
            [InParameter] public int RoleId;
        }

        [ProcedureName("DeleteChatUser")]
        internal class SPDeleteChatUser : StoredProcedure
        {
            [InParameter] public long UserId;
            [InParameter] public long ChatId;
        }
    }

    namespace Users
    {
        [ProcedureName("CreateUser")]
        internal class SPCreateUser : StoredProcedure
        {
            [InParameter] public string Nickname;
            [InParameter] public string Email;
            [InParameter] public string HashedPassword;
        }
    }

    namespace Messages
    {
        [ProcedureName("CreateMessage")]
        internal class SPCreateMessage : StoredProcedure
        {
            [InParameter] public string Text;
            [InParameter] public DateTime CreationTime;
            [InParameter] public long ChatId;
            [InParameter] public long SenderId;
        }

        [ProcedureName("UpdateMessage")]
        internal class SPUpdateMessage : StoredProcedure
        {
            [InParameter] public long Id;
            [InParameter] public DateTime CreationTime;
            [InParameter] public string Text;
        }

        [ProcedureName("DeleteMessage")]
        internal class SPDeleteMessage : StoredProcedure
        {
            [InParameter] public long Id;
        }

        [ProcedureName("GetMessage")]
        internal class SPGetMessage : StoredProcedure
        {
            [InParameter] public long Id;
        }

        [ProcedureName("GetMessages")]
        internal class SPGetMessages : StoredProcedure
        {
            [InParameter] public long ChatId;
        }
    }
}
