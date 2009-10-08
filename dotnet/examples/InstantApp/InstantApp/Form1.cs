using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using InstantApp.Models;
using InstantApp.Models.Mappings;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Linq;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;

namespace InstantApp
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();

			//get list of users and bind to grid
			var session = CreateSessionFactory().OpenSession();
			var list = from c in session.Linq<User>()
					   select c;

			dataGridView1.AutoGenerateColumns = true;
			dataGridView1.DataSource = list.ToList();			
		}

		public ISessionFactory CreateSessionFactory()
		{
			ISessionFactory sessionFactory = Fluently.Configure()
					.Database(SQLiteConfiguration.Standard
						.UsingFile(Program.DbFile))
					.Mappings(m =>
						m.FluentMappings.AddFromAssemblyOf<Tests>())
					.BuildSessionFactory();

			return sessionFactory;
		}
	}
}
