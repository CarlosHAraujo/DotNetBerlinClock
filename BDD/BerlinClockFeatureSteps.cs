using TechTalk.SpecFlow;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BerlinClock.Classes;

namespace BerlinClock
{
    [Binding]
    public class TheBerlinClockSteps
    {
        private ITimeConverter berlinClock = new BerlinClockConverter(new BerlinClockTime(new SecondBlinkProvider(), new FiveHoursLineProvider(), new OneHourLineProvider(), new FiveMinutesLineProvider(), new OneMinuteLineProvider()), new BerlinClockFormater());
        private string theTime;

        
        [When(@"the time is ""(.*)""")]
        public void WhenTheTimeIs(string time)
        {
            theTime = time;
        }

        [Then(@"the clock should look like")]
        public void ThenTheClockShouldLookLike(string theExpectedBerlinClockOutput)
        {
            Assert.AreEqual(theExpectedBerlinClockOutput, berlinClock.ConvertTime(theTime));
        }
    }
}
