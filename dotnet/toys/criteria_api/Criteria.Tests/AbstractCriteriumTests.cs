using System;
using System.Collections.Generic;
using System.Text;
using Criteria;
using Criteria.Query;
using Criteria.Tests.Helpers;
using MbUnit.Framework;

namespace Criteria.Tests
{
    [TestFixture]
    public class AbstractCriteriumTests
    {
        [Test]
        public void test_criterium_shards()
        {
            CriteriaVisitor visitor = new CriteriaVisitor();

            AbstractCriterium ands = new AndCriterium();

            ands.Add(new EqualsCriteria("id", 2));
            ands.Add(new GreaterThanCriteria("id", 2));
            ands.Add(new LessThanCriteria("id", 2));
            ands.Add(new LikeCriteria("id", 2));

            List<string> shards = new List<string>();
            foreach(ICriteria criteria in ands)
                shards.Add( criteria.GetShard(visitor) );

            Assert.IsNotEmpty(shards);
            
            string joined = String.Empty;
            foreach(string shard in shards)
                joined += shard + ",";

            DebugHelper.WriteToConsole("joined = " + joined);
            Assert.AreEqual("id = '2',id > '2',id < '2',id like '%2%',", joined);
        }
    }
}
