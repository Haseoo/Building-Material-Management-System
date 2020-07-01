using NHibernate;

namespace com.Github.Haseoo.BMMS.Data
{
    public class SessionWrapper
    {
        public SessionWrapper(ISession session)
        {
            Session = session;
        }

        public ISession Session { get; set; }
    }
}