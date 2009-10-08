using System;
using System.Text;
using FluentMigrator;

namespace InstantApp.schema
{
	[Migration(1)]
	public class First : Migration
	{
		public override void Up()
		{
			//users table
			Create.Table("Users")
				.WithColumn("Id").AsInt32().NotNullable().PrimaryKey()
				.WithColumn("Email").AsString(100).NotNullable()
				.WithColumn("Name").AsString(100).NotNullable()
				.WithColumn("Password").AsString(100).NotNullable();

			for(int loop = 0; loop < 10; loop++)
			{
				Insert.IntoTable("Users").Row(new { Id = loop, Email = string.Format("email{0}@mail.com", loop),
													Name = string.Format("test name{0}", loop),
													Password = string.Format("password{0}", loop)
				});
			}
		}

		public override void Down()
		{
			Delete.Table("Users");
		}
	}
}
