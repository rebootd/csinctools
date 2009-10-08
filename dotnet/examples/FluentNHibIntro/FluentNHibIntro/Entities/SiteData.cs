using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FluentNHibIntro.Entities
{
    public class SiteData
    {
        public virtual int Id { get; private set; }
        public virtual string Name { get; set; }
        public virtual IList<WebLink> WebLinks { get; set; }

        public SiteData()
        {
            WebLinks = new List<WebLink>();
        }

        public virtual void AddWebLink(WebLink link)
        {
            //link.SiteData = this;
            WebLinks.Add(link);
        }
    }
}
