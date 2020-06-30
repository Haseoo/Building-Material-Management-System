using com.Github.Haseoo.BMMS.Data.Entities;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;

namespace com.Github.Haseoo.BMMS.IntegrationTests.Config
{
    public class InMemorySessionFactoryProvider
    {
        private static InMemorySessionFactoryProvider _instance;
        private Configuration _configuration;

        private ISessionFactory _sessionFactory;

        private InMemorySessionFactoryProvider()
        {
        }

        public static InMemorySessionFactoryProvider Instance =>
            _instance ?? (_instance = new InMemorySessionFactoryProvider());

        public void Initialize()
        {
            _sessionFactory = CreateSessionFactory();
        }

        private ISessionFactory CreateSessionFactory()
        {
            return Fluently.Configure()
                .Database(SQLiteConfiguration.Standard.InMemory().ShowSql())
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Entity>())
                .ExposeConfiguration(cfg => _configuration = cfg)
                .BuildSessionFactory();
        }

        public ISession OpenSession()
        {
            var session = _sessionFactory.OpenSession();
            var export = new SchemaExport(_configuration);
            export.Execute(true, true, false, session.Connection, null);
            return session;
        }

        public void Dispose()
        {
            _sessionFactory?.Dispose();
            _sessionFactory = null;
            _configuration = null;
        }
    }
}