using System.Collections.Generic;

namespace IHI.Server.Networking.Messages
{
    public class MPermissions : OutgoingMessage
    {
        public IEnumerable<string> FuseRights
        {
            get;
            set;
        }

        public override OutgoingMessage Send(IMessageable target)
        {
            if (InternalOutgoingMessage.ID == 0)
            {
                InternalOutgoingMessage.Initialize(2);
                foreach(string fuseRight in FuseRights)
                {
                    InternalOutgoingMessage.AppendString(fuseRight);
                }
            }

            target.SendMessage(InternalOutgoingMessage);
            return this;
        }
    }
}