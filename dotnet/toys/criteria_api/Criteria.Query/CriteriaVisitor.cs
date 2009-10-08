using System;
using System.Collections.Generic;
using System.Text;
using Criteria;

namespace Criteria.Query
{
    public class CriteriaVisitor : AbstractCriteriaVisitor
    {
        public override string GetShard(EqualsCriteria criteria)
        {
            return String.Format("{0} = '{1}'", criteria.Field, criteria.Value.ToString());
        }

        public override string GetShard(GreaterThanCriteria criteria)
        {
            return String.Format("{0} > '{1}'", criteria.Field, criteria.Value.ToString());
        }

        public override string GetShard(LessThanCriteria criteria)
        {
            return String.Format("{0} < '{1}'", criteria.Field, criteria.Value.ToString());
        }

        public override string GetShard(LikeCriteria criteria)
        {
            return String.Format("{0} like '%{1}%'", criteria.Field, criteria.Value.ToString());
        }
    }
}
