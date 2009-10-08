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
    public class CriteriaVisitorTests
    {
        [Test]
        public void test_equals_visit()
        {
            CriteriaVisitor visitor = new CriteriaVisitor();
            EqualsCriteria criteria = new EqualsCriteria("id", 2);

            string shard = criteria.GetShard(visitor);

            DebugHelper.WriteToConsole("shard = " + shard);
            Assert.AreEqual("id = '2'", shard);
        }

        [Test]
        public void test_greater_than_visit()
        {
            CriteriaVisitor visitor = new CriteriaVisitor();
            GreaterThanCriteria criteria = new GreaterThanCriteria("id", 2);

            string shard = criteria.GetShard(visitor);

            DebugHelper.WriteToConsole("shard = " + shard);
            Assert.AreEqual("id > '2'", shard);
        }

        [Test]
        public void test_less_than_visit()
        {
            CriteriaVisitor visitor = new CriteriaVisitor();
            LessThanCriteria criteria = new LessThanCriteria("id", 2);

            string shard = criteria.GetShard(visitor);

            DebugHelper.WriteToConsole("shard = " + shard);
            Assert.AreEqual("id < '2'", shard);
        }

        [Test]
        public void test_like_visit()
        {
            CriteriaVisitor visitor = new CriteriaVisitor();
            LikeCriteria criteria = new LikeCriteria("id", 2);

            string shard = criteria.GetShard(visitor);

            DebugHelper.WriteToConsole("shard = " + shard);
            Assert.AreEqual("id like '%2%'", shard);
        }
    }
}
