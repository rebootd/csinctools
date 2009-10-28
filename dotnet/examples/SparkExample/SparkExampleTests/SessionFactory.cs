using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;
using NUnit.Framework;
using FluentNHibernate;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Linq;
using SparkExampleWeb.Models;

namespace SparkExampleTests
{
	[TestFixture]
	public class SessionFactory
	{
		private static string DbFile = MigrationTests.DbFile;
		private static string ConnectionString = MigrationTests.DbFile;

		public static ISessionFactory CreateSessionFactory()
		{
			ISessionFactory sessionFactory = Fluently.Configure()
					.Database(SQLiteConfiguration.Standard
						.UsingFile(DbFile))
					.Mappings(m =>
						m.FluentMappings.AddFromAssemblyOf<User>())
					.BuildSessionFactory();

			return sessionFactory;
		}

		[Test]
		public void can_get_nhsession()
		{
			//make sure the fnh mappings work and you can get an ISession
			ISessionFactory factory = CreateSessionFactory();

			Assert.True(true);
		}
	}
}
