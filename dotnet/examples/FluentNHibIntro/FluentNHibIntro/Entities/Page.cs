using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FluentNHibIntro.Entities
{
    public class Page
    {
        public virtual int Id { get; private set; }
        public virtual string Name { get; set; }
        public virtual string Content { get; set; }
        public virtual bool IsPublished { get; set; }
        //public virtual string Title { get; set; }
    }
}
