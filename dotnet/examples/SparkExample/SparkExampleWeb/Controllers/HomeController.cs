using System;
using System.Linq;
using System.Web.Mvc;
using System.Linq;
using SparkExampleWeb;
using SparkExampleWeb.Models;
using NHibernate;
using NHibernate.Linq;

namespace SparkExampleWeb.Controllers
{
	[HandleError]
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			ViewData["Message"] = "Welcome to ASP.NET MVC!";

			return View();
		}

		public ActionResult About()
		{
			return View();
		}

		public ActionResult List()
		{
			var session = SessionFactory.CreateSessionFactory().OpenSession();
			var users = from c in session.Linq<User>()
					   select c;

			return View(users.ToList());
		}
	}
}
