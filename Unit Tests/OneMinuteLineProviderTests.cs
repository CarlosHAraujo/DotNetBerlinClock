using BerlinClock.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BerlinClock.UnitTests
{
    [TestClass]
    public class OneMinuteLineProviderTests
    {
        [TestMethod]
        public void Should_Have_All_LampsOff_When_Is_Begining_Of_Hour()
        {
            OneMinuteLineProvider provider = new();
            Assert.AreEqual("OOOO", provider.GetLamps(0));
        }

        [TestMethod]
        public void Should_Have_All_LampsOn_When_Is_End_Of_Hour()
        {
            OneMinuteLineProvider provider = new();
            Assert.AreEqual("YYYY", provider.GetLamps(59));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Should_Throw_OutOfRange_When_Time_Is_Negative()
        {
            OneMinuteLineProvider provider = new();
            _ = provider.GetLamps(-1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Should_Throw_OutOfRange_When_Time_Is_Greater_Than_Expected()
        {
            OneMinuteLineProvider provider = new();
            _ = provider.GetLamps(61);
        }
    }
}
