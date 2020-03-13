using System;

namespace Chatter.DAL.Infrastructure.Attributes
{
    // Добавить название параметра
    [AttributeUsage(AttributeTargets.Field)]
    public class InParameter : Attribute
    {
    }
}
