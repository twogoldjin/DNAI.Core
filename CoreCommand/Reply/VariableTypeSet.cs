﻿namespace CoreCommand.Reply
{
    [ProtoBuf.ProtoContract]
    public class VariableTypeSet
    {
        [ProtoBuf.ProtoMember(1)]
        public Command.SetVariableType Command { get; set; }
    }
}