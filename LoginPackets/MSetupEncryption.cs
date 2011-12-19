namespace IHI.Server.Networking.Messages
{
    public class MSetupEncryption : OutgoingMessage
    {
        public bool UnknownA
        {
            get;
            set;
        }

        public override OutgoingMessage Send(IMessageable target)
        {
            if (InternalOutgoingMessage.ID == 0)
            {
                InternalOutgoingMessage.Initialize(277)
                    .AppendBoolean(UnknownA);
            }
            target.SendMessage(InternalOutgoingMessage);
            return this;
        }
    }
}