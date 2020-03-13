using Chatter.DAL.Infrastructure;
using Chatter.DAL.Infrastructure.Attributes;

namespace Chatter.DAL.StoredProcedures
{
    namespace Chats
    {
        [ProcedureName("SP_AddChat")]
        public class AddChatSP : StoredProcedure
        {
            [InParameter] public string Name;
        }

        [ProcedureName("SP_DeleteChat")]
        public class DeleteChatSP : StoredProcedure
        {
            [InParameter] public int Id;
        }

        [ProcedureName("SP_GetChats")]
        public class GetChatsSP : StoredProcedure
        {
        }

        [ProcedureName("SP_GetChatById")]
        public class GetChatByIdSP : StoredProcedure
        {
            [InParameter] public int ChatId;
        }

        [ProcedureName("SP_UpdateChat")]
        public class UpdateChatSP : StoredProcedure
        {
            [InParameter] public int Id;
            [InParameter] public string Name;
        }
    }

    namespace Messages
    {
        [ProcedureName("SP_CreateMessage")]
        public class CreateMessageSP : StoredProcedure
        {
            [InParameter] public string Text;
            [InParameter] public DateTime TimeStamp;
            [InParameter] public int ChatId;
        }

        [ProcedureName("SP_GetMessageById")]
        public class GetMessageByIdSP : StoredProcedure
        {
            [InParameter] public int MessageId;
        }

        [ProcedureName("SP_UpdateMessage")]
        public class UpdateMessageSP : StoredProcedure
        {
            [InParameter] public int Id;
            [InParameter] public string Text;
            [InParameter] public DateTime TimeStamp;
            [InParameter] public int ChatId;
        }

        [ProcedureName("SP_DeleteMessage")]
        public class DeleteMessageSP : StoredProcedure
        {
            [InParameter] public int Id;
        }

        [ProcedureName("SP_GetMessagesByChatId")]
        public class GetMessagesByChatIdSP : StoredProcedure
        {
            [InParameter] public int ChatId;
        }
    }
}
