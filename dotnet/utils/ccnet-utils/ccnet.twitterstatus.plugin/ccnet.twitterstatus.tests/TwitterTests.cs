using System;
using System.Collections.Generic;
using System.Xml;
using System.Text;
using Yedda;
using NUnit.Framework;

namespace ccnet.twitterstatus.tests
{
    [TestFixture]
    public class TwitterTests
    {
        private Yedda.Twitter twitter;        

        public TwitterTests()
        {
            twitter = new Twitter();
        }

        /// <summary>
        /// test to make sure the twitter library is working
        /// </summary>
        [Test]
        public void SendTweet()
        {
            string message = "test tweet";
            //tweet
            twitter.UpdateAsJSON(TwitterStatusUtil.user, TwitterStatusUtil.password, message);
            Assert.IsTrue(true);

            string currentStatus = TwitterStatusUtil.GetCurrentStatus(TwitterStatusUtil.user, TwitterStatusUtil.password);

            Assert.AreEqual(message, currentStatus);
        }
    }
}
