using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using Yedda;

namespace ccnet.twitterstatus.tests
{
    public class TwitterStatusUtil
    {
        public static string user = "csinctw1";
        public static string password = "some invalid password";

        public static string GetCurrentStatus(string user, string password)
        {
            Twitter twitter = new Twitter();

            //get user status history
            XmlDocument featuredXml = twitter.GetUserTimelineAsXML(user, password);            

            //get status nodes
            XmlNodeList statii = featuredXml.SelectNodes("//status");

            //first not is most recent
            XmlNode node = statii[0];

            //get text node
            XmlNode textNode = node.SelectSingleNode("//text");

            //return status
            return textNode.InnerText;
        }
    }
}
