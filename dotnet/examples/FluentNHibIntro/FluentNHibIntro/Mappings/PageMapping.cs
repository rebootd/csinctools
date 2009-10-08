using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using FluentNHibIntro.Entities;

namespace FluentNHibIntro.Mappings
{
    public class PageMapping : ClassMap<Page>
    {
        public PageMapping()
        {
            Id(x => x.Id);
            Map(x => x.Name);
            Map(x => x.Content);
            Map(x => x.IsPublished);
            //Map(x => x.Title);
        }
    }
}
