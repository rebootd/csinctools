using System;
using System.Collections.Generic;
using System.Text;

namespace Criteria
{
    public class EqualsCriteria : BaseCriteria
    {
        public EqualsCriteria(string field, object val) : base(field, val)
        {
        }

        public override string GetShard(AbstractCriteriaVisitor visitor)
        {
            return visitor.GetShard(this);
        }
    }
}
