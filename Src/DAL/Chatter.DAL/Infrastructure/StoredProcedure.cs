using System.Collections.Generic;

namespace Chatter.DAL.Infrastructure
{
    public abstract class StoredProcedure
    {
        public string ProcedureName { get; set; }
        public IEnumerable<ProcedureParam> ProcedureParams { get; private set; } // ReadOnly

        public StoredProcedure(string procedureName, params ProcedureParam[] procedureParams)
        {
            ProcedureName = procedureName;
            ProcedureParams = procedureParams;
        }
    }
}
