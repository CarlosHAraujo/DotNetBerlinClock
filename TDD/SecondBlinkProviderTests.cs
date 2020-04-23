using BerlinClock.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BerlinClock.TDD
{
    [TestClass]
    public class SecondBlinkProviderTests
    {
        [TestMethod]
        public void Should_Be_Off_When_Second_Is_Odd()
        {
            var provider = new SecondBlinkProvider();
            Assert.AreEqual("O", provider.GetLamps(1));
        }

        [TestMethod]
        public void Should_Be_On_When_Second_Is_Even()
        {
            var provider = new SecondBlinkProvider();
            Assert.AreEqual("Y", provider.GetLamps(2));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Should_Throw_OutOfRange_When_Time_Is_Negative()
        {
            var provider = new SecondBlinkProvider();
            _ = provider.GetLamps(-1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Should_Throw_OutOfRange_When_Time_Is_Greater_Than_Expected()
        {
            var provider = new SecondBlinkProvider();
            _ = provider.GetLamps(61);
        }
    }
}
