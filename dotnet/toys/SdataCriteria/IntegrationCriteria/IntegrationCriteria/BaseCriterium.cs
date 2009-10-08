using System;
using System.Collections.Generic;
using System.Text;

namespace IntegrationCriteria
{
    public class BaseCriterium : Expression
    {
        List<Expression> criteriaExpressions;

        public BaseCriterium()
        {
            criteriaExpressions = new List<Expression>();
        }
    }
}
