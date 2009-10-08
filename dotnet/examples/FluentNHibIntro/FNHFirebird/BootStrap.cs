using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using FNHFirebird.Entities;
using FNHFirebird.Mappings;
using FirebirdSql.Data;
using FirebirdSql.Data.FirebirdClient;
using FirebirdSql.Data.Isql;

namespace FNHFirebird
{
    public class BootStrap
    {
        private ISessionFactory _sessionFactory = null;
        private string _userName, _password = null;

        public string ConnectionString { get; private set; }
        public string DbFile { get; private set; }

        FirebirdConfiguration firebird = null;
        FluentConfiguration firebirdConfig = null;

        public BootStrap()
        {
            _userName = "test";
            _password = "test";
            DbFile = "test.db";
            ConnectionString = String.Format("ServerType=1;User={0};Password={1};Dialect=3;Database={2}", _userName, _password, DbFile);

            //setup firebird configuration
            firebird = new FirebirdConfiguration();
            firebirdConfig = Fluently.Configure().Database(
                     firebird.ConnectionString(c => c
                     .Is(ConnectionString)));
        }

        /// <summary>
        /// need to construct the Firebird config here...
        /// </summary>
        /// <returns></returns>
        public ISessionFactory CreateSessionFactory()
        {
            if (_sessionFactory == null)
            {
                _sessionFactory = firebirdConfig.Mappings(m => m.FluentMappings.AddFromAssemblyOf<BootStrap>())
                    .ExposeConfiguration(BuildSchema)
                    .BuildSessionFactory();
            }

            return _sessionFactory;
        }

        private void BuildSchema(Configuration config)
        {
            //quit if it alread exists
            if (File.Exists(DbFile)) return;
            
            //user firebird to create the database
            FbConnection.CreateDatabase(ConnectionString);

            // this NHibernate tool takes a configuration (with mapping info in)
            // and exports a database schema from it
            new SchemaExport(config)
                .Create(false, true);
        }
    }
}
