namespace IHI.Server.Networking.Messages
{
    public class MVolumeLevel : OutgoingMessage
    {
        private readonly int _volume;

        /// <summary>
        /// Set the volume level of the client.
        /// </summary>
        public MVolumeLevel()
        {
        }

        /// <summary>
        /// Set the volume level of the client.
        /// </summary>
        public MVolumeLevel(int volume)
        {
            _volume = volume;
        }

        public override OutgoingMessage Send(IMessageable target)
        {
            if (InternalOutgoingMessage.ID == 0)
            {
                InternalOutgoingMessage.Initialize(308).
                    AppendInt32(_volume);
            }

            target.SendMessage(InternalOutgoingMessage);
            return this;
        }
    }
}