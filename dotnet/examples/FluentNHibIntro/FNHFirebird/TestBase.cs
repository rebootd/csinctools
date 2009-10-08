using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using MbUnit.Framework;
using FNHFirebird.Entities;
using FNHFirebird.Mappings;

namespace FNHFirebird
{
    public class TestBase
    {
        private static BootStrap BootStrapper = null;

        public TestBase()
        {
            if (BootStrapper == null)
            {
                BootStrapper = new BootStrap();
                SetupData();
            }
        }

        public void SetupData()
        {
            var sessionFactory = BootStrapper.CreateSessionFactory();
            using (var session = sessionFactory.OpenSession())
            {
                // populate the database
                using (var transaction = session.BeginTransaction())
                {
                    //links
                    var link1 = new WebLink { URL = "http://semperfifund.org", Name = "semper fi fund", OpenNewWindow = true };
                    var link2 = new WebLink { URL = "http://www.woundedwarriorproject.org/", Name = "wounded warriors", OpenNewWindow = true };
                    var link3 = new WebLink { URL = "http://www.sunshineacres.org/", Name = "sunshine acres", OpenNewWindow = true };

                    SaveLinks(session, link1, link2, link3);

                    transaction.Commit();
                }
            }
        }

        private void SaveLinks(ISession session, params WebLink[] links)
        {
            foreach (var link in links)
                session.SaveOrUpdate(link);
        }

        [Test]
        public void have_links()
        {
            var sessionFactory = BootStrapper.CreateSessionFactory();
            using (var session = sessionFactory.OpenSession())
            {
                // retreive all stores and display them
                using (session.BeginTransaction())
                {
                    //get the first siteData.. should only be one anyway
                    var links = session.CreateCriteria(typeof(WebLink)).List<WebLink>();

                    //make sure there are links
                    Assert.GreaterThan(links.Count, 0);
                }
            }
        }
    }
}
