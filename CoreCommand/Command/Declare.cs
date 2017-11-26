﻿using CoreControl;
using System;

namespace CoreCommand.Command
{
    [ProtoBuf.ProtoContract]
    public class Declare
    {
        [ProtoBuf.ProtoMember(1)]
        public EntityFactory.ENTITY EntityType { get; set; }

        [ProtoBuf.ProtoMember(2)]
        public UInt32 ContainerID { get; set; }

        [ProtoBuf.ProtoMember(3)]
        public string Name { get; set; }

        [ProtoBuf.ProtoMember(4)]
        public EntityFactory.VISIBILITY Visibility { get; set; }
    }
}