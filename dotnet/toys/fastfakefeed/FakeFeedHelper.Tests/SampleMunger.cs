using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using FakeFeedHelper.Definitions;

namespace FakeFeedHelper.Tests
{
    public class SampleMunger : IDataMunger
    {
        #region IDataMunger Members

        public void MungeNodeData(ref XmlNode node)
        {
            //this is where we mangle the data in the node

            //get the ownder document
            XmlDocument xmlDoc = node.OwnerDocument;

            XmlNamespaceManager nsmanager = new XmlNamespaceManager(xmlDoc.NameTable);
            nsmanager.AddNamespace("atom", "http://www.w3.org/2005/Atom");
            nsmanager.AddNamespace("sdata", "http://schemas.sage.com/sdata/2008/1");

            //now do something
            if (node.SelectSingleNode("sdata:payload/atom:contact/atom:applicationId", nsmanager)!=null) 
                node.SelectSingleNode("sdata:payload/atom:contact/atom:applicationId", nsmanager).InnerText = "test1";
        }

        #endregion
    }
}
