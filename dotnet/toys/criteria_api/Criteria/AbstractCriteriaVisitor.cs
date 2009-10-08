using System;
using System.Collections.Generic;
using System.Text;

namespace Criteria
{
    public abstract class AbstractCriteriaVisitor
    {
        public abstract string GetShard(EqualsCriteria criteria);
        public abstract string GetShard(GreaterThanCriteria criteria);
        public abstract string GetShard(LessThanCriteria criteria);
        public abstract string GetShard(LikeCriteria criteria);
    }
}
