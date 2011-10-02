using IHI.Server.Habbos;

namespace IHI.Server.Networking.Messages
{
    public class MUserData : OutgoingMessage
    {
        private HabboFigure _figure;
        private int _habboID;
        private string _motto;
        private string _username;

        /// <summary>
        /// Inform the client that it has been logged in.
        /// </summary>
        public MUserData()
        {
        }

        /// <summary>
        /// Inform the client that it has been logged in.
        /// </summary>
        public MUserData(int habboID, string username, HabboFigure figure, string motto)
        {
            _habboID = habboID;
            _username = username;
            _figure = figure;
            _motto = motto;
        }

        public MUserData(Habbo habbo)
        {
            _habboID = habbo.GetID();
            _username = habbo.GetUsername();
            _figure = habbo.GetFigure() as HabboFigure;
            _motto = habbo.GetMotto();
        }

        public MUserData SetHabboID(int habboID)
        {
            _habboID = habboID;
            return this;
        }

        public MUserData SetUsername(string username)
        {
            _username = username;
            return this;
        }

        public MUserData SetFigure(HabboFigure figure)
        {
            _figure = figure;
            return this;
        }

        public MUserData SetMotto(string motto)
        {
            _motto = motto;
            return this;
        }

        public override OutgoingMessage Send(IMessageable target)
        {
            if (InternalOutgoingMessage.ID == 0)
            {
                InternalOutgoingMessage.Initialize(5)
                    .AppendString(_habboID.ToString())
                    .AppendString(_username)
                    .AppendString(_figure.ToString())
                    .AppendString(_figure.GetGenderChar().ToString())
                    .AppendString(_motto)
                    .AppendInt32(0)
                    .Append((byte) 2)
                    .AppendInt32(0)
                    .AppendInt32(0)
                    .AppendInt32(10) // Respect apparently
                    .AppendInt32(3) // Givable respect apparently
                    .AppendInt32(5); // "Pet respect" apparently... I need to catch up on flash...
            }

            target.SendMessage(InternalOutgoingMessage);
            return this;
        }
    }
}