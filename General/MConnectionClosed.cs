﻿namespace IHI.Server.Networking.Messages
{
    public class MConnectionClosed : OutgoingMessage
    {
        public ConnectionClosedReason Reason
        {
            get;
            set;
        }

        public override OutgoingMessage Send(IMessageable target)
        {
            if (InternalOutgoingMessage.ID == 0)
            {
                InternalOutgoingMessage.Initialize(287)
                    .AppendInt32((int) Reason);
            }

            target.SendMessage(InternalOutgoingMessage);
            return this;
        }
    }
}