using BerlinClock.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BerlinClock.UnitTests
{
    [TestClass]
    public class BerlinClockTimeTests
    {
        private BerlinClockTime clock;

        [TestInitialize]
        public void Setup()
        {
            clock = new BerlinClockTime(new SecondBlinkProvider(), new FiveHoursLineProvider(), new OneHourLineProvider(), new FiveMinutesLineProvider(), new OneMinuteLineProvider());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Should_Throw_ArgumentNullException_When_Time_Is_Null()
        {
            clock.Parse(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Should_Throw_ArgumentException_When_Time_Is_empty()
        {
            clock.Parse("");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Should_Throw_ArgumentException_When_Time_Is_Incorrect()
        {
            clock.Parse("24:");
        }
    }
}
