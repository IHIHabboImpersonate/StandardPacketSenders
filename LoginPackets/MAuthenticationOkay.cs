namespace IHI.Server.Networking.Messages
{
    public class MAuthenticationOkay : OutgoingMessage
    {
        public override OutgoingMessage Send(IMessageable target)
        {
            if (InternalOutgoingMessage.ID == 0)
            {
                InternalOutgoingMessage.Initialize(3);
            }
            target.SendMessage(InternalOutgoingMessage);
            return this;
        }
    }
}