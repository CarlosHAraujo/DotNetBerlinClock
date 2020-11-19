namespace BerlinClock.Classes
{
    public class BerlinClockConverter : ITimeConverter
    {
        private readonly BerlinClockTime _berlinClockTime;

        //Readiness for DI
        public BerlinClockConverter(BerlinClockTime berlinClockTime)
        {
            _berlinClockTime = berlinClockTime;
        }

        public string ConvertTime(string aTime)
        {
            var time = _berlinClockTime.Parse(aTime);
            return time.ToString();
        }
    }
}
