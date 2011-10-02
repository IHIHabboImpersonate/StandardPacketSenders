namespace IHI.Server.Networking.Messages
{
    public class MSecretKey : OutgoingMessage
    {
        private string _key;

        public MSecretKey()
        {
        }

        public MSecretKey(string key)
        {
            _key = key;
        }

        public MSecretKey SetKey(string key)
        {
            _key = key;
            return this;
        }

        public override OutgoingMessage Send(IMessageable target)
        {
            if (InternalOutgoingMessage.ID == 0)
            {
                InternalOutgoingMessage.Initialize(1)
                    .AppendString(_key);
            }
            target.SendMessage(InternalOutgoingMessage);
            return this;
        }
    }
}