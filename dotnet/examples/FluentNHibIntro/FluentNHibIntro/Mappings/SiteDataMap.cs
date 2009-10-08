using System.Collections.Generic;
using FluentNHibernate.Mapping;
using FluentNHibIntro.Entities;

namespace FluentNHibIntro.Mappings
{
    public class SiteDataMap : ClassMap<SiteData>
    {
        public SiteDataMap()
        {
            Id(x => x.Id);
            Map(x => x.Name);
            HasMany(x => x.WebLinks)
                .Cascade.All()
                .Inverse();
        }
    }
}
