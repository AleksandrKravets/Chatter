using System;
using System.Runtime.Serialization;

namespace Chatter.Application.Infrastructure
{
    [DataContract]
    [Serializable]
    public class BaseResponse : IResponse
    {
        [DataMember] public ResponseStatus Status { get; set; }
    }
}
