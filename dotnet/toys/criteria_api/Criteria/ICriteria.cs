using System;
using System.Collections.Generic;
using System.Text;

namespace Criteria
{
    public interface ICriteria
    {
        object Value { get; set; }
        string Field { get; set; }

        string GetShard(AbstractCriteriaVisitor visitor);
    }
}
