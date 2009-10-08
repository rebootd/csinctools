using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.XPath;

using FakeFeedHelper.Definitions;

namespace FakeFeedHelper
{
    public class Feeder
    {
        private string xmlFilePath;

        public Feeder(string xmlFilePath)
        {
            this.xmlFilePath = xmlFilePath;
        }

        public XmlDocument GetNewFeed(int nodesToChange, DateTime newUpdateDate, IDataMunger dataMunger)
        {
            //make int array size of nodesToChange
            int[] nodeIndices = new int[nodesToChange];

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(this.xmlFilePath);

            XmlNamespaceManager nsmanager = new XmlNamespaceManager(xmlDoc.NameTable);
            nsmanager.AddNamespace("atom", "http://www.w3.org/2005/Atom");
            //xmlns:atom="http://www.w3.org/2005/Atom" xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:cf="http://www.microsoft.com/schemas/rss/core/2005" xmlns="http://www.w3.org/2005/Atom" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:http="http://schemas.sage.com/sdata/http/2008/1" xmlns:sme="http://schemas.sage.com/sdata/sme/2007" xmlns:sdata="http://schemas.sage.com/sdata/2008/1"

            var nodeList = xmlDoc.SelectNodes("//atom:entry", nsmanager);

            //fill int array with randomn numbers between zero and {number of AtomEntries in feed}, all different
            int maxCount = nodeList.Count - 1;
            Random rand = new Random(DateTime.Now.Millisecond);
            for(int loop = 0; loop < nodesToChange; loop++)
            {
                int index = rand.Next(maxCount);
                nodeIndices[loop] = index;
            }

            //get corresponding node for each 
            foreach (int index in nodeIndices)
            {
                XmlNode node = nodeList[index];

                //set update date
                node.SelectSingleNode("//atom:updated", nsmanager).InnerText = newUpdateDate.ToFileTimeUtc().ToString();

                //call datamunger on node
                dataMunger.MungeNodeData(ref node);
            }

            //return altered document
            return xmlDoc;
        }

        public bool FileExists()
        {
            return File.Exists(this.xmlFilePath);
        }
    }
}
