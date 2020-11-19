using BerlinClock.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BerlinClock.UnitTests
{
    [TestClass]
    public class OneHourLineProviderTest
    {
        [TestMethod]
        public void Should_Have_All_LampsOff_When_Is_AMPM_Midnight()
        {
            OneHourLineProvider provider = new();
            Assert.AreEqual("OOOO", provider.GetLamps(0));
        }

        [TestMethod]
        public void Should_Have_All_LampsOn_When_Is_24Midnight()
        {
            OneHourLineProvider provider = new();
            Assert.AreEqual("RRRR", provider.GetLamps(24));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Should_Throw_OutOfRange_When_Time_Is_Greater_Than_Expected()
        {
            OneHourLineProvider provider = new();
            _ = provider.GetLamps(25);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Should_Throw_OutOfRange_When_Time_Is_Negative()
        {
            OneHourLineProvider provider = new();
            _ = provider.GetLamps(-1);
        }
    }
}
