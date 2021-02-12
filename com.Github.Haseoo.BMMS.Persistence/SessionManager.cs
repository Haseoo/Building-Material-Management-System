using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.Github.Haseoo.BMMS.Data
{
    public class SessionManager : IDisposable
    {
        private SessionManager()
        {
        }

        private readonly ISessionFactory _sessionFactory = SessionFactoryBuilder.BuildSessionFactory();
        private ISession _session;
        private bool _disposed = false;

        public ISession GetSession()
        {
            if (_session == null)
            {
                _session = _sessionFactory.OpenSession();
            }
            return _session;
        }

        public void AcquireNewSession()
        {
            if (_session == null)
            {
                GetSession();
            } else {
                _session.Close();
                _session = _sessionFactory.OpenSession();
            }
        }

         public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed  || _session == null) return;

            if (disposing)
            {
                _session.Dispose();
            }

            _disposed = true;
        }

        public static readonly SessionManager Instance = new SessionManager();

    }
}
