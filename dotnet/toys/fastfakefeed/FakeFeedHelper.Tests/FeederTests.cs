using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using FakeFeedHelper;
using FakeFeedHelper.Definitions;
using NUnit.Framework;

namespace FakeFeedHelper.Tests
{
    [TestFixture]
    public class FeederTests
    {
        private const string XML_FILE_PATH = @"samplefeed.xml";
        private const int NODE_COUNT = 10;

        [Test]
        public void get_simple_instance()
        {
            var feeder = new Feeder(XML_FILE_PATH);

            Assert.IsNotNull(feeder);
        }

        [Test]
        public void check_file_exists()
        {
            var feeder = new Feeder(XML_FILE_PATH);

            Assert.IsNotNull(feeder);
            Assert.AreEqual(true, feeder.FileExists());
        }

        [Test]
        public void test_sample_munger()
        {
            var feeder = new Feeder(XML_FILE_PATH);

            var munger = new SampleMunger();

            Assert.IsNotNull(feeder);
            Assert.AreEqual(true, feeder.FileExists());

            var doc = feeder.GetNewFeed(NODE_COUNT, DateTime.Now, munger);

            XmlNamespaceManager nsmanager = new XmlNamespaceManager(doc.NameTable);
            nsmanager.AddNamespace("atom", "http://www.w3.org/2005/Atom");
            nsmanager.AddNamespace("sdata", "http://schemas.sage.com/sdata/2008/1");

            Assert.IsNotNull(doc);
            Assert.AreEqual(NODE_COUNT, doc.ChildNodes[1].SelectNodes("//atom:applicationId[text()='test1']", nsmanager).Count);
        }
    }
}
