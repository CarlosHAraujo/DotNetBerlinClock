namespace BerlinClock.Classes
{
    public class TimeConverter : ITimeConverter
    {
        public string ConvertTime(string aTime)
        {
            return BerlinClock.Convert(aTime);
        }
    }
}
