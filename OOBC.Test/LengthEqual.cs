using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace OOBC.Test
{
    [TestClass]
    public class LengthEqual
    {
        [TestMethod]
        public void should_1m_equal_1m()
        {
            var length1M = new Length(1, new MUnit());
            var otherLength1M = new Length(1, new MUnit());
            Assert.AreEqual(length1M, otherLength1M);
        }

        [TestMethod]
        public void should_1m_equal_100cm()
        {
            var length1M = new Length(1, new MUnit());
            var length100Cm = new Length(100, new CMUnit());
            Assert.AreEqual(length1M, length100Cm);
        }

        [TestMethod]
        public void should_1m_equal_1000mm()
        {
            var length1M = new Length(1, new MUnit());
            var length1000Mm = new Length(1000, new MMUnit());
            Assert.AreEqual(length1M, length1000Mm);
        }
    }
}
