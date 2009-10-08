using System;
using System.Collections.Generic;
using System.Text;

namespace Criteria
{
    public class LikeCriteria : BaseCriteria
    {
        public LikeCriteria(string field, object val)
            : base(field, val)
        {
        }

        public override string GetShard(AbstractCriteriaVisitor visitor)
        {
            return visitor.GetShard(this);
        }
    }
}
