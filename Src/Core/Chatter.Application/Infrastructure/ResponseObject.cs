using System;
using System.Runtime.Serialization;

namespace Chatter.Application.Infrastructure
{
    [DataContract]
    [Serializable]
    public class ResponseObject
    {
        [DataMember] public object Result { get; set; }
        [DataMember] public ResponseStatus Status { get; set; }
    }
}
