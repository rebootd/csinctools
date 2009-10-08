using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace FakeFeedHelper.Definitions
{
    public interface IDataMunger
    {
        void MungeNodeData(ref XmlNode node);
    }
}
