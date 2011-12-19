using IHI.Server.Habbos;

namespace IHI.Server.Networking.Messages
{
    public class MHabboData : OutgoingMessage
    {
        public HabboFigure Figure
        {
            get;
            set;
        }
        public int HabboID
        {
            get;
            set;
        }
        public string Motto
        {
            get;
            set;
        }
        public string UnknownA
        {
            get;
            set;
        }
        public string Username
        {
            get;
            set;
        }

        public override OutgoingMessage Send(IMessageable target)
        {
            if (InternalOutgoingMessage.ID == 0)
            {
                InternalOutgoingMessage.Initialize(5)
                    .AppendString(HabboID.ToString())
                    .AppendString(Username) // TODO: Should this be display name?
                    .AppendString(Figure.ToString())
                    .AppendString(Figure.GetGenderChar().ToString())
                    .AppendString(Motto)
                    .AppendString(UnknownA)
                    .AppendInt32(12) // TODO: Find out what this does.
                    .AppendString(Figure.GetFormattedSwimFigure())
                    .AppendBoolean(false)
                    .AppendBoolean(true);
            }

            target.SendMessage(InternalOutgoingMessage);
            return this;
        }
    }
}