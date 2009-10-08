using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InstantApp.Models
{
	public class User
	{
		public virtual int Id { get; set; }
		public virtual string Email { get; set; }
		public virtual string Name { get; set; }
		public virtual string Password { get; set; }
	}
}
