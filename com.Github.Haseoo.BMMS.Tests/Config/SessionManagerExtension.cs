using com.Github.Haseoo.BMMS.Data;
using NHibernate;
using System.Reflection;

namespace com.Github.Haseoo.BMMS.Tests.Config
{
    public static class SessionManagerExtension
    {
        public static void SetSession(this SessionManager sessionManager, ISession session)
        {
            sessionManager
                .GetType()
                .GetField("_session", BindingFlags.Instance | BindingFlags.NonPublic)
                ?.SetValue(sessionManager, session);
        }
    }
}
