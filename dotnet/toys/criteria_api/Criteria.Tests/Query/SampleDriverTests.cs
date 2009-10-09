using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using Criteria;
using Criteria.Query;
using Criteria.Tests.Helpers;

namespace Criteria.Tests.Query
{
    [TestFixture]
    public class SampleDriverTests
    {
        [Test]
        public void test_sample_driver()
        {
            AndCriterium ands = new AndCriterium();

            ands.Add(new EqualsCriteria("id", 2));
            ands.Add(new GreaterThanCriteria("id", 2));
            ands.Add(new LessThanCriteria("id", 2));
            ands.Add(new LikeCriteria("id", 2));

            Assert.IsNotEmpty(ands);

            string query = SampleDriver.GetQuery(ands);

            DebugHelper.WriteToConsole("query = " + query);
            Assert.AreEqual("id = '2' and id > '2' and id < '2' and id like '%2%'", query);
        }
    }
}
