using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using FluentNHibIntro.Entities;
using FluentNHibIntro.Mappings;

namespace FluentNHibIntro
{
    /// <summary>
    /// this is where I wind up the firebird and fluent nhib config
    /// </summary>
    public class BootStrap
    {
        private ISessionFactory _sessionFactory = null;

        public string DbFile { get; private set; }

        public BootStrap()
        {
            DbFile = "test.db";
        }

        public ISessionFactory CreateSessionFactory()
        {
            if (_sessionFactory == null)
            {
                _sessionFactory = Fluently.Configure()
                    .Database(SQLiteConfiguration.Standard
                        .UsingFile(DbFile))
                    .Mappings(m =>
                        m.FluentMappings.AddFromAssemblyOf<BootStrap>())
                    .ExposeConfiguration(BuildSchema)
                    .BuildSessionFactory();
            }

            return _sessionFactory;
        }

        /// <summary>
        /// this is where we manage database schema and versioning; still working on how to handle versioning.
        /// </summary>
        /// <param name="config"></param>
        private void BuildSchema(Configuration config)
        {
            if (File.Exists(DbFile))
                new SchemaUpdate(config).Execute(true, true);
            else
                new SchemaExport(config).Create(false, true);
        }
    }
}
