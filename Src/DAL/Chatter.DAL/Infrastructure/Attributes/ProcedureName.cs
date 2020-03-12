using System;

namespace Chatter.DAL.Infrastructure.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class ProcedureName : Attribute
    {
        public string Name { get; set; }

        public ProcedureName(string name)
        {
            Name = name;
        }
    }
}
