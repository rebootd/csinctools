using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using Criteria;

namespace Criteria.Query
{
    public class SampleDriver
    {
        public static string GetQuery(AndCriterium criterium)
        {
            CriteriaVisitor visitor = new CriteriaVisitor();

            StringBuilder sb = new StringBuilder();

            int loop = 0;
            foreach (ICriteria criteria in criterium)
            {
                sb.Append(criteria.GetShard(visitor));

                if (loop == criterium.Count - 1) break;

                sb.Append(" and ");
                loop++;
            }

            return sb.ToString();
        }
    }
}
