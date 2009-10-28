using System;
using FluentNHibernate.Mapping;

namespace SparkExampleWeb.Models.Maps
{
	public class UserMap : ClassMap<User>
	{
		public UserMap()
		{
			//map to Users table
			this.Table("Users");
			Id(x => x.Id).GeneratedBy.Assigned();
			Map(x => x.Name).Length(100).Not.Nullable();
			Map(x => x.Email).Length(100).Not.Nullable();
			Map(x => x.Password).Length(100).Not.Nullable();
		}
	}
}
