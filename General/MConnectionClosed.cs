namespace IHI.Server.Networking.Messages
{
    public class MConnectionClosed : OutgoingMessage
    {
        private ConnectionClosedReason _reason;

        public MConnectionClosed()
        {
        }

        public MConnectionClosed(ConnectionClosedReason reason)
        {
            _reason = reason;
        }

        public MConnectionClosed SetReason(ConnectionClosedReason reason)
        {
            _reason = reason;
            return this;
        }

        public override OutgoingMessage Send(IMessageable target)
        {
            if (InternalOutgoingMessage.ID == 0)
            {
                InternalOutgoingMessage.Initialize(287)
                    .AppendInt32((int) _reason);
            }

            target.SendMessage(InternalOutgoingMessage);
            return this;
        }
    }
}