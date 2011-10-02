namespace IHI.Server.Networking.Messages
{
    public class MSessionParams : OutgoingMessage
    {
        private readonly int _a;
        private readonly int _b;
        private readonly int _c;
        private readonly int _d;
        private readonly string _dateFormat;
        private readonly int _e;
        private readonly int _f;
        private readonly int _g;
        private readonly int _h;
        private readonly int _i;
        private readonly int _j;
        private readonly int _k;
        private readonly int _l;
        private readonly int _m;
        private readonly int _n;
        private readonly int _o;
        private readonly int _p;
        private readonly int _q;
        private readonly string _url;

        public MSessionParams(int a, int b, int c, int d, int e, int f, int g, int h, int i, int j, int k, int l,
                              string dateFormat, int m, int n, int o, string url, int p, int q)
        {
            _a = a;
            _b = b;
            _c = c;
            _d = d;
            _e = e;
            _f = f;
            _g = g;
            _h = h;
            _i = i;
            _j = j;
            _k = k;
            _l = l;
            _dateFormat = dateFormat;
            _m = m;
            _n = n;
            _o = o;
            _url = url;
            _p = p;
            _q = q;
        }

        public override OutgoingMessage Send(IMessageable target)
        {
            if (InternalOutgoingMessage.ID == 0)
            {
                InternalOutgoingMessage.Initialize(257)
                    .AppendInt32(_a)
                    .AppendInt32(_b)
                    .AppendInt32(_c)
                    .AppendInt32(_d)
                    .AppendInt32(_e)
                    .AppendInt32(_f)
                    .AppendInt32(_g)
                    .AppendInt32(_h)
                    .AppendInt32(_i)
                    .AppendInt32(_j)
                    .AppendInt32(_k)
                    .AppendInt32(_l)
                    .AppendString(_dateFormat)
                    .AppendInt32(_m)
                    .AppendInt32(_n)
                    .AppendInt32(_o)
                    .AppendString(_url)
                    .AppendInt32(_p)
                    .AppendInt32(_q);
            }

            target.SendMessage(InternalOutgoingMessage);
            return this;
        }
    }
}