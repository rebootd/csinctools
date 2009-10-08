using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FNHFirebird.Entities
{
    public class WebLink
    {
        public virtual Guid Id { get; private set; }
        public virtual string URL { get; set; }
        public virtual string Name { get; set; }
        public virtual bool OpenNewWindow { get; set; }
    }
}
