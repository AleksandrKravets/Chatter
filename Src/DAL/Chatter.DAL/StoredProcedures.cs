using Quantum.DAL.Infrastructure;
using Quantum.DAL.Infrastructure.Attributes;

namespace Chatter.DAL.StoredProcedures
{
    namespace Chats
    {
        [ProcedureName("CreateChat")]
        internal class SPCreateChat : StoredProcedure
        {
            [InParameter] public string Name;
            [InParameter] public int CreatorId;
            [InParameter] public int ChatTypeId;
        }

        [ProcedureName("DeleteChat")]
        internal class SPDeleteChat : StoredProcedure
        {
            [InParameter] public int Id;
        }

        [ProcedureName("GetChat")]
        internal class SPGetChatById : StoredProcedure
        {
            [InParameter] public int Id;
        }

        [ProcedureName("GetChats")]
        internal class SPGetChats : StoredProcedure
        {
        }

        [ProcedureName("UpdateChat")]
        internal class SPUpdateChat : StoredProcedure
        {
            [InParameter] public int Id;
            [InParameter] public string Name;
        }

        [ProcedureName("GetChatByName")]
        internal class SPGetChatByName : StoredProcedure
        {
            [InParameter] public string Name;
        }
    }
}
