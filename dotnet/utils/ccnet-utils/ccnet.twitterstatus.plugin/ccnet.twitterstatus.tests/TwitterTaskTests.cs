using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MbUnit.Framework;
using ThoughtWorks.CruiseControl.Core;
using ThoughtWorks.CruiseControl.Remote;
using ccnet.twitterstatus.plugin;
using Rhino.Mocks;

namespace ccnet.twitterstatus.tests
{
    [TestFixture]
    public class TwitterTaskTests
    {
        public TwitterTaskTests()
        {
            
        }

        /// <summary>
        /// test to see if the build task class sends a message to twitter
        /// </summary>
        [Test]
        public void TweetTaskTest()
        {
            MockRepository mocks = new MockRepository();
            //mock the integration result interface
            IIntegrationResult integrationResult = mocks.StrictMock<IIntegrationResult>();
            Expect.Call(integrationResult.Status).Return(IntegrationStatus.Success).Repeat.AtLeastOnce();
            Expect.Call(integrationResult.ProjectName).Return("TweetTask").Repeat.AtLeastOnce();
            Expect.Call(delegate { integrationResult.AddTaskResult(""); }).IgnoreArguments().Repeat.Any();
            Expect.Call(delegate { integrationResult.AddTaskResult(new TwitterTaskResult("")); }).IgnoreArguments().Repeat.Any();
            mocks.ReplayAll();

            //create the twitter task object
            TwitterTask twitTask = new TwitterTask();

            //set the properties
            twitTask.User = TwitterStatusUtil.user;
            twitTask.Password = TwitterStatusUtil.password;
            twitTask.IncludeMachineName = false;
            twitTask.Message = "some sample unit test message.";

            //call Run
            twitTask.Run(integrationResult);

            mocks.VerifyAll();

            //short pause to give twitter time...
            System.Threading.Thread.Sleep(200);

            //make sure the status was updated..
            string currentStatus = TwitterStatusUtil.GetCurrentStatus(TwitterStatusUtil.user, TwitterStatusUtil.password);
            Assert.IsTrue( currentStatus.IndexOf(twitTask.Message) >= 0 );
        }
    }
}
