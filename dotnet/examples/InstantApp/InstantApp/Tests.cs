using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using InstantApp.Models;
using InstantApp.Models.Mappings;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Linq;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using FluentMigrator;
using FluentMigrator.Runner;
using FluentMigrator.Runner.Generators;
using FluentMigrator.Runner.Processors;
using FluentMigrator.Runner.Versioning;
using Xunit;

namespace InstantApp
{
	public class Tests
	{
		private static string DbFile = "test.db";
		private static string ConnectionString = "Data Source=test.db;Version=3;";

		public void RunMigration()
		{
			if (!File.Exists(DbFile))
				System.Data.SQLite.SQLiteConnection.CreateFile(DbFile);

			//run migration
			using (SQLiteConnection connection = new SQLiteConnection(ConnectionString))
			{
				var conventions = new MigrationConventions();
				connection.Open();
				var processor = new FluentMigrator.Runner.Processors.Sqlite.SqliteProcessor(connection, new SqliteGenerator());
				var runner = new MigrationVersionRunner(conventions, processor, new MigrationLoader(conventions));

				//upgrade to latest
				runner.UpgradeToLatest(false);
			}
		}

		public ISessionFactory CreateSessionFactory()
		{
			ISessionFactory sessionFactory = Fluently.Configure()
					.Database(SQLiteConfiguration.Standard
						.UsingFile(DbFile))
					.Mappings(m =>
						m.FluentMappings.AddFromAssemblyOf<Tests>())
					.BuildSessionFactory();

			return sessionFactory;
		}

		[Fact]
		public void can_run_migration()
		{
			RunMigration();

			//yes, lame.. either throws exception or passes.
			Assert.True(true);
		}

		[Fact]
		public void can_get_nhsession()
		{
			//make sure the fnh mappings work and you can get an ISession
			ISessionFactory factory = CreateSessionFactory();

			Assert.True(true);
		}

		[Fact]
		public void get_list_all_users()
		{
			var session = CreateSessionFactory().OpenSession();
			var list = from c in session.Linq<User>()
					   select c;
			Assert.True(list.ToList().Count == 10);
		}
	}
}
