using System;
using System.Collections.Generic;
using System.Text;
using Criteria;
using MbUnit.Framework;

namespace Criteria.Tests
{
    [TestFixture]
    public class BaseCriteriaTests
    {
        [Test]
        public void create_equals_criteria()
        {
            EqualsCriteria cri = new EqualsCriteria("id", 1);

            Assert.IsNotNull(cri);
            Assert.AreEqual(1, cri.Value);
        }
    }
}
