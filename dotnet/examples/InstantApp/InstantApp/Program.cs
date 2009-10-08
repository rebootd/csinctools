using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using FluentMigrator;
using FluentMigrator.Runner;
using FluentMigrator.Runner.Generators;
using FluentMigrator.Runner.Processors;
using FluentMigrator.Runner.Versioning;

namespace InstantApp
{
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			//run migrations
			MigrateDatabase();

			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new Form1());
		}

		public static string DbFile = "data.db";
		public static string ConnectionString = "Data Source=data.db;Version=3;";
		static void MigrateDatabase()
		{
			//make sure the sqlite db file exists
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
	}
}
