using System;
using System.Collections.Generic;
using System.Text;
using Exortech.NetReflector;
using ThoughtWorks.CruiseControl.Core;
using ThoughtWorks.CruiseControl.Core.Util;
using Yedda;

namespace ccnet.twitterstatus.plugin
{
    /// <summary>
    /// for adding a twitter status task in cruisecontrol
    /// ccnet xml will look like this:
    /// <cruisecontrol>
	/// <project name="myproject">
	/// 	<tasks>
	/// 		<twittertask>
	/// 			<!-- include custom builder properties here -->
    /// 			<user>twitter-username</user>
    /// 			<password>twitter-password</password>
    /// 			<includemachinename>true|false[optional]</includemachinename>
    /// 			<message>some short messge to include</message>
    /// 		</twittertask>
	/// 	</tasks>
	/// </project>
    /// </cruisecontrol>
    /// </summary>
    [ReflectorType("twitterstatus")]
    public class TwitterTask : ITask
    {
        private Yedda.Twitter twitter;

        [ReflectorProperty("user", Required = true)]
        public string User { get; set; }

        [ReflectorProperty("password", Required = true)]
        public string Password { get; set; }

        [ReflectorProperty("includemachinename", Required = false)]
        public bool IncludeMachineName{ get; set; }

        [ReflectorProperty("message", Required = false)]
        public string Message { get; set; }

        public TwitterTask()
        {
            twitter = new Twitter();
        }

        public string GetTweetText()
        {
            return GetTweetText(null);
        }

        public string GetTweetText(IIntegrationResult result)
        {
            StringBuilder sb = new StringBuilder();

            //include machine name
            if (IncludeMachineName)
            {
                sb.Append("[");
                sb.Append(Environment.MachineName);
                sb.Append("] ");
            }

            //added custom message
            if (Message != null && Message.Trim().Length > 0)
            {
                sb.Append(Message);
                sb.Append(" ");
            }

            //add build status... should normally have this
            try
            {
                if (result != null)
                {
                    sb.Append("project=");
                    sb.Append(result.ProjectName);
                    sb.Append(" ");
                    sb.Append("status=");
                    sb.Append(result.Status.ToString());
                    sb.Append(" ");
                }
            }
            catch
            {
                //ignoring exceptions here..
            }

            //limit to twitter's limit of 140 chars..
            return sb.ToString();
        }

        #region ITask Members

        public void Run(IIntegrationResult result)
        {
            try
            {
                //set status to success if unknow..
                if (result != null && result.Status == ThoughtWorks.CruiseControl.Remote.IntegrationStatus.Unknown)
                {
                    result.Status = ThoughtWorks.CruiseControl.Remote.IntegrationStatus.Success;
                }

                //tweet status
                twitter.UpdateAsJSON(User, Password, GetTweetText(result));

                //update task result
                if (result != null)
                {
                    result.AddTaskResult( new TwitterTaskResult(this.Message) );                    
                }
            }
            catch (Exception er)
            {
                if (result != null)
                {
                    result.Status = ThoughtWorks.CruiseControl.Remote.IntegrationStatus.Exception;
                }

                throw new CruiseControlException(String.Format("TwitterTask process error:  {0} ", er.Message));
            }
        }

        #endregion
    }
}
