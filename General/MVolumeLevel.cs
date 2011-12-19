namespace IHI.Server.Networking.Messages
{
    public class MVolumeLevel : OutgoingMessage
    {
        public int Volume
        {
            get;
            set;
        }


        public override OutgoingMessage Send(IMessageable target)
        {
            if (InternalOutgoingMessage.ID == 0)
            {
                InternalOutgoingMessage.Initialize(308).
                    AppendInt32(Volume);
            }

            target.SendMessage(InternalOutgoingMessage);
            return this;
        }
    }
}