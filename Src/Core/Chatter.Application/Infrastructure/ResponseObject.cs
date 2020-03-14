﻿using System;
using System.Runtime.Serialization;

namespace Chatter.Application.Infrastructure
{
    [DataContract]
    [Serializable]
    public class ResponseObject : BaseResponse
    {
        [DataMember] public object Result { get; set; }
    }
}
