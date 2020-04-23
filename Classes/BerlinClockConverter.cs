namespace BerlinClock.Classes
{
    public class BerlinClockConverter : ITimeConverter
    {
        private readonly BerlinClockFormater formater;
        private readonly BerlinClockTime berlinClockTime;

        //Readiness for DI
        public BerlinClockConverter(BerlinClockTime berlinClockTime, BerlinClockFormater formater)
        {
            this.berlinClockTime = berlinClockTime;
            this.formater = formater;
        }

        public string ConvertTime(string aTime)
        {
            var time = berlinClockTime.Parse(aTime);
            return formater.Format(time.Seconds, time.FiveHours, time.OneHour, time.FiveMinutes, time.OneMinute);
        }
    }
}
