using IHI.Server.Habbos;

namespace IHI.Server.Networking.Messages
{
    public class MCreditBalance : OutgoingMessage
    {
        private int _balance;

        /// <summary>
        /// Inform the client that it has been logged in.
        /// </summary>
        public MCreditBalance()
        {
        }

        public MCreditBalance(int balance)
        {
            _balance = balance;
        }

        public MCreditBalance(Habbo habbo)
        {
            _balance = habbo.GetCreditBalance();
        }

        public MCreditBalance SetCreditBalance(int balance)
        {
            _balance = balance;
            return this;
        }

        public override OutgoingMessage Send(IMessageable target)
        {
            if (InternalOutgoingMessage.ID == 0)
            {
                InternalOutgoingMessage.Initialize(6)
                    .AppendString(_balance.ToString());
            }

            target.SendMessage(InternalOutgoingMessage);
            return this;
        }
    }
}