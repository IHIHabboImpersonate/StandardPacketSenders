namespace IHI.Server.Networking.Messages
{
    public class MPermissions : OutgoingMessage
    {
        private bool _permission1;
        private bool _permission2;

        /// <summary>
        /// Sends two permissions. Not sure what these are yet
        /// </summary>
        public MPermissions()
        {
        }

        /// <summary>
        /// Sends two permissions. Not sure what these are yet
        /// </summary>
        /// <param name="permission1">Not sure yet</param>
        /// <param name="permission2">Not sure yet</param>
        public MPermissions(bool permission1, bool permission2)
        {
            _permission1 = permission1;
            _permission2 = permission2;
        }

        public MPermissions SetPermission1(bool value)
        {
            _permission1 = value;
            return this;
        }

        public MPermissions SetPermission2(bool value)
        {
            _permission2 = value;
            return this;
        }

        public override OutgoingMessage Send(IMessageable target)
        {
            if (InternalOutgoingMessage.ID == 0)
            {
                InternalOutgoingMessage.Initialize(2)
                    .AppendBoolean(_permission1)
                    .AppendBoolean(_permission2);
            }

            target.SendMessage(InternalOutgoingMessage);
            return this;
        }
    }
}