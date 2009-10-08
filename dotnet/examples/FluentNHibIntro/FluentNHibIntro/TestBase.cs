using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using FluentNHibIntro.Entities;
using FluentNHibIntro.Mappings;
using NUnit.Framework;

namespace FluentNHibIntro
{
    [TestFixture]
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
                    //site
                    //var site = new SiteData { Name = "csinc" };

                    //links
                    var link1 = new WebLink { URL = "http://semperfifund.org", Name = "semper fi fund", OpenNewWindow = true };
                    var link2 = new WebLink { URL = "http://www.woundedwarriorproject.org/", Name = "wounded warriors", OpenNewWindow = true };
                    var link3 = new WebLink { URL = "http://www.sunshineacres.org/", Name = "sunshine acres", OpenNewWindow = true };

                    SaveLinks(session, link1, link2, link3);
                    
                    //pages
                    var page1 = new Page { Name = "first-page", Content = "this is test content", IsPublished = true };
                    var page2 = new Page { Name = "first-page", Content = "this is test content", IsPublished = true };
                    SavePages(session, page1, page2);

                    transaction.Commit();
                }
            }
        }

        private void SaveLinks(ISession session, params WebLink[] links)
        {
            foreach (var link in links)
                session.SaveOrUpdate(link);
        }

        private void SavePages(ISession session, params Page[] pages)
        {
            foreach (var page in pages)
                session.SaveOrUpdate(page);
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
                    Assert.Greater(links.Count, 0);
                }
            }
        }

        [Test]
        public void have_pages()
        {
            var sessionFactory = BootStrapper.CreateSessionFactory();
            using (var session = sessionFactory.OpenSession())
            {
                // retreive all stores and display them
                using (session.BeginTransaction())
                {
                    //get the first siteData.. should only be one anyway
                    var pages = session.CreateCriteria(typeof(Page)).List<Page>();

                    //make sure there are links
                    Assert.Greater(pages.Count, 0);
                }
            }
        }
    }
}
