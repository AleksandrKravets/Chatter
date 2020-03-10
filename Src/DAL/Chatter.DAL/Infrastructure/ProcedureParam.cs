namespace Chatter.DAL.Infrastructure
{
    public class ProcedureParam
    {
        public string Key { get; private set; }
        public object Value { get; private set; }

        public ProcedureParam(string key, object value)
        {
            Key = key;
            Value = value;
        }
    }
}
