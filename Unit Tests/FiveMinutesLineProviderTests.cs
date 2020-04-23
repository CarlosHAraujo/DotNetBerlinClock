using BerlinClock.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BerlinClock.UnitTests
{
    [TestClass]
    public class FiveMinutesLineProviderTests
    {
        [TestMethod]
        public void Should_Have_All_LampsOff_When_Is_Begining_Of_Hour()
        {
            var provider = new FiveMinutesLineProvider();
            Assert.AreEqual("OOOOOOOOOOO", provider.GetLamps(0));
        }

        [TestMethod]
        public void Should_Have_All_LampsOn_When_Is_End_Of_Hour()
        {
            var provider = new FiveMinutesLineProvider();
            Assert.AreEqual("YYRYYRYYRYY", provider.GetLamps(59));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Should_Throw_OutOfRange_When_Time_Is_Negative()
        {
            var provider = new FiveMinutesLineProvider();
            _ = provider.GetLamps(-1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Should_Throw_OutOfRange_When_Time_Is_Greater_Than_Expected()
        {
            var provider = new FiveMinutesLineProvider();
            _ = provider.GetLamps(61);
        }
    }
}
