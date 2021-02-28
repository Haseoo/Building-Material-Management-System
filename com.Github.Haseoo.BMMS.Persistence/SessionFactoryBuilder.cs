using System;
using System.Configuration;
using com.Github.Haseoo.BMMS.Data.Entities;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Dialect;
using NHibernate.Tool.hbm2ddl;

namespace com.Github.Haseoo.BMMS.Data
{
    public static class SessionFactoryBuilder
    {
        public static ISessionFactory BuildSessionFactory(bool create = false, bool update = false)
        {
            return Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2012
                    .ConnectionString(
                        String.Format("Server={0};Database={1};User Id={2};Password={3};",
                        ConfigurationManager.AppSettings.Get("server"),
                        ConfigurationManager.AppSettings.Get("database"),
                        ConfigurationManager.AppSettings.Get("user"),
                        ConfigurationManager.AppSettings.Get("password")))
                    .Dialect<MsSql2012Dialect>()
                    .ShowSql()
                )
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Entity>())
                .CurrentSessionContext("call")
                .ExposeConfiguration(cfg => BuildSchema(cfg, create, update))
                .BuildSessionFactory();
        }

        private static void BuildSchema(NHibernate.Cfg.Configuration config, bool create = false, bool update = false)
        {
            if (create)
                new SchemaExport(config).Create(false, true);
            else
                new SchemaUpdate(config).Execute(false, update);
        }
    }
}