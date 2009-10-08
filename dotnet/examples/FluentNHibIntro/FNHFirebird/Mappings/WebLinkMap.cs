using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using FNHFirebird.Entities;

namespace FNHFirebird.Mappings
{
    public class WebLinkMap : ClassMap<WebLink>
    {
        public WebLinkMap()
        {
            Id(x => x.Id).GeneratedBy.Guid();
            Map(x => x.URL);
            Map(x => x.Name);
            Map(x => x.OpenNewWindow);
        }
    }
}
