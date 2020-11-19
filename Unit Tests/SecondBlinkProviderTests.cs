using BerlinClock.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BerlinClock.UnitTests
{
    [TestClass]
    public class SecondBlinkProviderTests
    {
        [TestMethod]
        public void Should_Be_Off_When_Second_Is_Odd()
        {
            SecondBlinkProvider provider = new();
            Assert.AreEqual('O', provider.GetLamps(1));
        }

        [TestMethod]
        public void Should_Be_On_When_Second_Is_Even()
        {
            SecondBlinkProvider provider = new();
            Assert.AreEqual('Y', provider.GetLamps(2));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Should_Throw_OutOfRange_When_Time_Is_Negative()
        {
            SecondBlinkProvider provider = new();
            _ = provider.GetLamps(-1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Should_Throw_OutOfRange_When_Time_Is_Greater_Than_Expected()
        {
            SecondBlinkProvider provider = new();
            _ = provider.GetLamps(61);
        }
    }
}
