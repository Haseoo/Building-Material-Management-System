using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using Entity = com.Github.Haseoo.BMMS.Data.Entities.Entity;

namespace com.Github.Haseoo.BMMS.IntegrationTests.Config
{
    public class InMemorySessionFactoryProvider
    {
        private static InMemorySessionFactoryProvider _instance;
        public static InMemorySessionFactoryProvider Instance => _instance ?? (_instance = new InMemorySessionFactoryProvider());

        private ISessionFactory _sessionFactory;
        private Configuration _configuration;

        private InMemorySessionFactoryProvider() { }

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