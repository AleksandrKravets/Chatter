using Chatter.DAL.Infrastructure;
using Chatter.DAL.Infrastructure.Attributes;
using Chatter.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Chatter.DAL.Repositories
{
    [ProcedureName("")]
    public class GetUserContactsSP : StoredProcedure
    {
        [InParameter] public int UserId;
    }

    [ProcedureName("")]
    public class CreateUserContactSP : StoredProcedure
    {
        [InParameter] public int UserId;
        [InParameter] public int ContactUserId;
    }

    [ProcedureName("")]
    public class DeleteUserContactSP : StoredProcedure
    {
        [InParameter] public int Id;
    }

    public class UserContactRepository
    {
        private readonly StoredProcedureExecutor _procedureExecutor;

        public UserContactRepository(StoredProcedureExecutor procedureExecutor)
        {
            _procedureExecutor = procedureExecutor;
        }

        public Task<IEnumerable<UserContact>> GetUserContactsAsync(int userId)
        {
            return _procedureExecutor.ExecuteListAsync<UserContact>(new GetUserContactsSP 
            { 
                UserId = userId 
            });
        }

        public Task CreateUserContactAsync(UserContact userContact)
        {
            return _procedureExecutor.ExecuteAsync(new CreateUserContactSP 
            { 
                UserId = userContact.UserId, 
                ContactUserId = userContact.ContactUserId 
            });
        }

        public Task DeleteUserContactAsync(int userContactId)
        {
            return _procedureExecutor.ExecuteAsync(new DeleteUserContactSP 
            { 
                Id = userContactId 
            });
        }
    }
}
