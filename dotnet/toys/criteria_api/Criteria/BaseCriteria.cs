using System;
using System.Collections.Generic;
using System.Text;

namespace Criteria
{
    public abstract class BaseCriteria : ICriteria
    {
        private string field;

        public string Field
        {
            get { return field; }
            set { field = value; }
        }

        private object val;

        public object Value
        {
            get { return val; }
            set { val = value; }
        }

        public abstract string GetShard(AbstractCriteriaVisitor visitor);

        public BaseCriteria(string field, object val)
        {
            this.field = field;
            this.val = val;
        }
    }
}
