using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using FluentNHibernate;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Linq;
using SparkExampleWeb.Models;

namespace SparkExampleTests.Models
{
	[TestFixture]
	public class UserTests
	{
		[Test]
		public void can_get_users()
		{
			//make sure migration has been run
			MigrationTests mig = new MigrationTests();
			mig.RunMigration();

			var session = SessionFactory.CreateSessionFactory().OpenSession();
			var list = from c in session.Linq<User>()
					   select c;
			Assert.True(list.ToList().Count == 10);
		}

		[Test]
		public void can_get_users_without_linq()
		{
			//make sure migration has been run
			MigrationTests mig = new MigrationTests();
			mig.RunMigration();

			var session = SessionFactory.CreateSessionFactory().OpenSession();
			var list = session.CreateCriteria<User>().List<User>();
			Assert.True(list.ToList().Count == 10);
		}
	}
}
