namespace IHI.Server.Networking.Messages
{
    public class MSecretKey : OutgoingMessage
    {
        public string Key
        {
            get;
            set;
        }

        public override OutgoingMessage Send(IMessageable target)
        {
            if (InternalOutgoingMessage.ID == 0)
            {
                InternalOutgoingMessage.Initialize(1)
                    .AppendString(Key);
            }
            target.SendMessage(InternalOutgoingMessage);
            return this;
        }
    }
}