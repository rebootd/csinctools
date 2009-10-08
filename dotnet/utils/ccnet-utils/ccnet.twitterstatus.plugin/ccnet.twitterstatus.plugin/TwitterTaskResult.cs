using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ThoughtWorks.CruiseControl.Core;

namespace ccnet.twitterstatus.plugin
{
    public class TwitterTaskResult : ITaskResult
    {
        private string data;

        public TwitterTaskResult(string message)
		{
            data = message;
		}

        #region ITaskResult Members

        public string Data
        {
            get { return data; }
        }

        public bool Failed()
        {
            return false;
        }

        public bool Succeeded()
        {
            return true;
        }

        #endregion
    }
}
