﻿using System;
using System.IO;
using System.Data.SQLite;
using FluentMigrator;
using FluentMigrator.Runner;
using FluentMigrator.Runner.Generators;
using NUnit.Framework;

namespace SparkExampleTests
{
	[TestFixture]
	public class MigrationTests
	{
		internal static string DbFile = "test.db";
		internal static string ConnectionString = "Data Source=test.db;Version=3;";

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
				var runner = new MigrationVersionRunner(conventions, processor, new MigrationLoader(conventions), typeof(SparkExampleWeb.Models.User));

				//upgrade to latest
				runner.UpgradeToLatest(false);
			}
		}

		[Test]
		public void can_run_migration()
		{
			RunMigration();

			//yes, lame.. either throws exception or passes.
			Assert.True(true);
		}
	}
}
