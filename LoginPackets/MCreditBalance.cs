using IHI.Server.Habbos;

namespace IHI.Server.Networking.Messages
{
    public class MCreditBalance : OutgoingMessage
    {
        public int Balance
        {
            get;
            set;
        }

        /// <summary>
        /// Constructs a new instance of MCreditBalance and sets the balance to that of a given Habbo.
        /// </summary>
        /// <param name="habbo"></param>
        public MCreditBalance(Habbo habbo)
        {
            Balance = habbo.GetCreditBalance();
        }

        public override OutgoingMessage Send(IMessageable target)
        {
            if (InternalOutgoingMessage.ID == 0)
            {
                InternalOutgoingMessage.Initialize(6)
                    .AppendString(Balance.ToString());
            }

            target.SendMessage(InternalOutgoingMessage);
            return this;
        }
    }
}